using Application.Controllers.Manager.User;
using Application.Controllers.Manager.User.Presenter;
using AutoMapper;
using Core.Models; 
using Microsoft.AspNetCore.Mvc;
using Core.Constant;
using Core;
using Application.Helpers;

namespace Application.Routers
{
    public class UserManagerRouter
    { 
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Users",
                    Path = "users",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async (DataContext db, IMapper mapper) => await new UserManagerCtrl(mapper, db).Get()
                },
				 new RouterModel()
				{
					Method = "GET",
					Module = "Users",
					Path = "users-roles",
					ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
					Action = async (DataContext db, IMapper mapper) => await new UserManagerCtrl(mapper, db).GetUsersWithRoles()
				},
				new RouterModel()
                {
                    Method = "POST",
                    Module = "Users",
                    Path = "users",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async ([FromBody] CreateUserPresenter model, DataContext db, IMapper mapper) => await new UserManagerCtrl(mapper, db).Create(model)
                },
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "Users",
                    Path = "users",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async ([FromBody] UpdateUserPresenter model, DataContext db, IMapper mapper) => await new UserManagerCtrl(mapper, db).Update(model)
                }
                ,new RouterModel()
                {
                    Method = "DELETE",
                    Module = "Users",
                    Path = "users",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action =  (long id, DataContext db, IMapper mapper) => new UserManagerCtrl(mapper, db).Delete(id)
                }
            };
            return routers;
        } 
    }
}
