using Application.Controllers.Manager.Role;
using Application.Controllers.Manager.Role.Presenter;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Constant;
using Core;
using Application.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Routers.Manager
{
    public class RoleManagerRouter
    {
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel> {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Roles",
                    Path = "roles",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async (DataContext db,HttpContext httpContext, IMapper mapper) => await new RoleManagerCtrl(httpContext,db, mapper).Get()
                },
				new RouterModel()
                {
                    Method = "POST",
                    Module = "Roles",
                    Path = "roles",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = ([FromBody] CreateRolePresenter model, HttpContext httpContext, DataContext db, IMapper mapper) => new RoleManagerCtrl(httpContext, db , mapper).Create(model)
                }, 
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "Roles",
                    Path = "roles",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = ([FromBody] UpdateRolePresenter model,HttpContext httpContext, DataContext db, IMapper mapper) => new RoleManagerCtrl(httpContext, db, mapper).Update(model)
                },
				 new RouterModel()
				{
					Method = "PUT",
					Module = "Roles",
					Path = "role-perms",
					ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
					Action = ([FromBody]  UpdatePermForRolePresenter model,HttpContext httpContext, DataContext db, IMapper mapper) => new RoleManagerCtrl(httpContext, db, mapper).UpdatePermForRole(model)
				},
				new RouterModel()
                {
                    Method = "DELETE",
                    Module = "Roles",
                    Path = "roles",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = (long id, DataContext db, IMapper mapper, HttpContext httpContext) => new RoleManagerCtrl(httpContext, db, mapper).Delete(id)
                }
            };
            return routers;
        }
    }
}
