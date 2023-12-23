using Microsoft.Extensions.Caching.Memory;
using Application.Routers;
using Core.Interfaces;
using Core.Models;
using Application.Helpers.ExceptionHandle;
using Infrastructure.Services;
using System.Text;
using Core.Schemas;
using Core.Constant;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Base.Application.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMemoryCache cacheService;
        private readonly ICacheService<PermSchema> permCacheService;
        public JwtMiddleware(RequestDelegate next, IMemoryCache _cacheService)
        {
            _next = next;
            cacheService = _cacheService;
            permCacheService = new CacheService<PermSchema>(cacheService);
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
                var secretKey = configuration["Configuration:SecretKey"];
                byte[] key = Encoding.ASCII.GetBytes(secretKey);
                var chatHub = context.RequestServices.GetRequiredService<IHubContext<SignalrHub, IHubClientService>>();

                IEnumerable<RouterModel> routers = new PublicRouter().Get(chatHub, key);

                var publicApi = routers.Select(x => x.Path).ToList();
                publicApi.Add("/chat");
                publicApi.Add("/notification");
                string? apiRequest = context?.Request?.Path.Value?.Replace("/api/", "");
                if (!publicApi.Contains(apiRequest))
                {
                    string? accessToken = context?.Request?.Headers["Authorization"].FirstOrDefault();
                    if (accessToken != null)
                    {
                        string token = accessToken.Replace("Bearer ", "");
                        var currentUserInfo = JwtUtil.GetUserInfoInToken(key, token);
                        if (currentUserInfo.UserId > 0)
                        {
                            var header = context.Request.Path.Value;
                            var httpMethod = context.Request.Method;
                            bool isAccess = VerifyPermission(header, httpMethod, currentUserInfo.Perms);
                            if (!isAccess)
                            {
                                throw new ForbiddenException("Forbidden");
                            }
                        }
                    }
                    else
                    {
                        throw new UnauthorizedException("Unauthorized");
                    }
                }
                await _next(context);
            }
            catch (Exception ex)
            {
                var exceptionHelper = new ExceptionHelper();
                await exceptionHelper.HandleExceptionAsync(context, ex);
            }
        }



        private bool VerifyPermission(string header, string httpMethod, List<string> perms)
        {
            bool isAccess = false;
            bool isRequestApi = header.Contains("/api/");
            if (isRequestApi)
            {
                var apiRequest = header.Replace("/api/", "").Split("/");

                string path = apiRequest.Length > 1 ? apiRequest[1] : apiRequest[0];
                string action = GetAction(apiRequest, httpMethod);
                string? perm = perms.Find(x => x.Equals(action + " " + path));
                isAccess = perm != null;
            }
            return isAccess;
        }


        private string GetAction(string[] apiRequest, string httpMethod)
        {
            string action = "";
            if (apiRequest.Length > 1)
            {
                var isNumeric = apiRequest.Length == 2 ? int.TryParse(apiRequest[1], out int n) : false;
                action = isNumeric ? httpMethod : apiRequest[0] + "/" + apiRequest[1];
            }
            else
            {
                action = httpMethod;
            }
            return action;
        }
    }

}
