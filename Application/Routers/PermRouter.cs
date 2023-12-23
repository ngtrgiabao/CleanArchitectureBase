using Core.Models;
using Core.Constant;
using Application.Controllers;
using Core;
using Application.Helpers;

namespace Application.Routers
{
    public class PermRouter
    { 
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>();
            var permRouter = new RouterModel()
            {
                Method = "GET",
                Module = "Perms",
                Path = "perms",
                ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE),
                Action = async (DataContext db) => await new PermCtrl(db).GetAllAsync()
            };
            routers.Add(permRouter);
            return routers;
        }
    }
}
