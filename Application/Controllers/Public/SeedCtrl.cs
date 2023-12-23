using Application.Routers;
using Core.Models;
using AutoMapper;
using Core;
using Infrastructure.Services;
using Microsoft.AspNetCore.SignalR;
using Core.Interfaces;
using Infrastructure.SignalRHub;

namespace Application.Controllers.PublicCtrl
{
    public class SeedCtrl : BaseController
    {
        private readonly SeedDataService seedService;

        public SeedCtrl(HttpContext _httpContext, DataContext ctx, byte[] _secretKey, IMapper _mapper, IHubContext<SignalrHub, IHubClientService> _hub)
            : base(_httpContext, ctx, _secretKey, _mapper, _hub)
        {
            seedService = new SeedDataService(ctx);
        }

        public async Task<IResult> Execute()
        {
            var routers = new ZRouterManager(hub, secretKey).Get();
            ResponseModel response = await seedService.Execute(routers);
            return Results.Ok(response);
        }
    }
}
