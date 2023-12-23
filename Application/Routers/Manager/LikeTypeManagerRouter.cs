using Core.Models;
using Core.Constant;
using Application.Controllers.Manager.LikeType;
using Microsoft.AspNetCore.Mvc;
using Core;
using Application.Helpers;

namespace Application.Routers.Manager
{
    public class LikeTypeManagerRouter
    {
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "LikeType",
                    Path = "like-type",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async (DataContext db) => await new LikeTypeManagerCtrl(db).GetAsync()
                },new RouterModel()
                {
                    Method = "POST",
                    Module = "LikeType",
                    Path = "like-type",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async ([FromBody] LikeTypePresenter model, DataContext db) => await new LikeTypeManagerCtrl(db).CreateAsync(model)
                },
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "LikeType",
                    Path = "like-type",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                    Action = async ([FromBody] LikeTypePresenter model, DataContext db) => await new LikeTypeManagerCtrl(db).UpdateAsync(model)
                }
            };

            return routers;
        }
    }
}
