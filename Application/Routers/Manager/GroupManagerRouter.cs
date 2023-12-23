using Application.Controllers.Manager;
using Core.Interfaces;
using Core.Models;
using Core.Constant;
using Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Application.Controllers.Manager.Group.Presenter;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class GroupManagerRouter
    {
        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> _hub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel> {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Groups",
                    Path = "groups",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await new GroupManagerCtrl(httpContext, db, secretKey, mapper, _hub).Get()
                },
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "Groups",
                    Path = "groups",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async ([FromBody] AdminUpdateGroupPresenter model ,HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await new GroupManagerCtrl( httpContext, db, secretKey, mapper, _hub).Update(model)
                }, new RouterModel()
                {
                    Method = "DELETE",
                    Module = "Groups",
                    Path = "groups",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action =  (int id,HttpContext httpContext, DataContext db, IMapper mapper) => 
                               new GroupManagerCtrl(httpContext, db, secretKey, mapper, _hub).Delete(id)
                }
            };
            return routers;
        }
    }
}
