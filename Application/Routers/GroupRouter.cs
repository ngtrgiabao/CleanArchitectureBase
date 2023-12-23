using AutoMapper;
using Core.Models;
using Core;
using Application.Controllers;
using Core.Constant;
using Application.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Application.Controllers.Group;
using Microsoft.AspNetCore.Mvc;
using Application.Controllers.Group.Presenter;
using System.Reflection;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class GroupRouter
    {
        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> _hub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel>();
            var routeInfos = new List<RouterModel>
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-category",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await  new GroupCtrl(httpContext, db, secretKey, mapper, _hub).FetchCategory()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-tag-group",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await  new GroupCtrl(httpContext, db, secretKey, mapper, _hub).FetchTagGroup()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-group-suggest",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await  new GroupCtrl(httpContext, db, secretKey, mapper,_hub).FetchGroupSuggest()
                },
				 new RouterModel()
				{
					Method = "POST",
					Module = "Feed",
					Path = "create-group",
					ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
					Action = async ([FromBody] CreateGroupPresenter model, HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await  new GroupCtrl(httpContext, db, secretKey, mapper,_hub).Create(model)
				},
				  new RouterModel()
				{
					Method = "PUT",
					Module = "Feed",
					Path = "update-group",
					ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
					Action = async ([FromBody] UpdateGroupPresenter model, HttpContext httpContext, DataContext db, IMapper mapper) =>
							 await  new GroupCtrl(httpContext, db, secretKey, mapper,_hub).Update(model)
				},
				  new RouterModel()
				{
					Method = "DELETE",
					Module = "Feed",
					Path = "delete-group",
					ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
					Action =  (long groupId, HttpContext httpContext, DataContext db, IMapper mapper) =>
							   new GroupCtrl(httpContext, db, secretKey, mapper,_hub).Delete(groupId)
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
