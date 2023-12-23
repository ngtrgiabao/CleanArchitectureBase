using AutoMapper;
using Core.Models;
using Core.Constant;
using Core;
using Microsoft.AspNetCore.Mvc;
using Application.Controllers.PublicCtrl;
using Application.Controllers.PublicCtrl.Presenter;
using Application.Controllers.Public;
using Core.Interfaces; 
using Microsoft.AspNetCore.SignalR; 
using Application.Controllers;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class PublicRouter
    { 
        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> _hub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel>();
            var routeInfos = new List<RouterModel>
            {
                  new RouterModel()
                  {
                        Method = "POST",
                        Module = "Auth",
                        Path = "auth/login",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = ([FromBody] LoginPresenter authPresenter, DataContext db, IMapper mapper) => 
                                 new LoginCtrl(db, secretKey, mapper).Execute(authPresenter)
                  },
                  new RouterModel()
                  {
                        Method = "POST",
                        Module = "Auth",
                        Path = "auth/refresh-token",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = ([FromBody] TokenPresenter model, DataContext db, IMapper mapper) => new RefreshTokenCtrl(db, secretKey, mapper).Execute(model)
                  },
                  new RouterModel()
                  {
                        Method = "POST",
                        Module = "Auth",
                        Path = "auth/register",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = ([FromBody] RegisterPresenter registerPresenter,  DataContext db, IMapper mapper) => new RegisterCtrl(db, mapper).Execute(registerPresenter)
                  },
                  new RouterModel()
                  {
                        Method = "GET",
                        Module = "Seed",
                        Path = "seed",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                                 await new SeedCtrl(httpContext, db, secretKey, mapper, _hub).Execute()
                  },
                  new RouterModel()
                  {
                        Method = "GET",
                        Module = "Options",
                        Path = "options",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = () => new OptionsCtrl().Get()
                  },
                  new RouterModel()
                  {
                        Method = "POST",
                        Module = "Upload",
                        Path = "upload",
                        ProfileType = PermUtil.PUBLIC_PROFILE,
                        Action = async (IFormFile file) => await new FileCtrl().Post(file)
                  }
            };

            foreach (var routeInfo in routeInfos)
            {
                routers.Add(routeInfo);
            }
            return routers;
        }
    }
}
