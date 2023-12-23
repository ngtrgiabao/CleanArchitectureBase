using Core.Interfaces;
using Core.Schemas;
using Core;
using Microsoft.EntityFrameworkCore;
using Core.Models;
using Core.Constant;
using Core.Business;

namespace Infrastructure.Services
{
    public class RoleService : BaseService<RoleSchema, DataContext>, IRoleService
    {
        DataContext context;
        public RoleService(DataContext _ctx) : base(_ctx)
        {
            context = _ctx;
        }

		public RoleSchema GetRoleByTitle( string title)
		{
            return context.Roles.FirstOrDefault(u =>  u.Title.Equals(title));
		}

		public List<RolePermModel> GetRolesWithPerms()
		{
			var roleWithPerms = dbContext.Roles.Include(r => r.RolesPerms)
							.ThenInclude(rp => rp.Perm)
							.Select(u => UserRule.GetPerm(u))
							.ToList();



			return roleWithPerms;
		}
		public async void AddRolesToUser(List<long> roleIds, long userId)
		{
			// delete perm not in list
			var oldRoles = dbContext.UsersRoles.Where(rp => !roleIds.Contains(rp.RoleId) && rp.UserId == userId);

			dbContext.UsersRoles.RemoveRange(oldRoles);


			foreach (var roleId in roleIds)
			{
				var userRole = dbContext.UsersRoles.FirstOrDefault(ur => ur.RoleId == roleId && ur.UserId == userId);
				if (userRole == null)
				{
					dbContext.UsersRoles.Add(new UsersRoles
					{
						RoleId = roleId,
						UserId = userId
					});
				}
			}
			dbContext.SaveChanges();
		}
		public List<RolePermModel> UpdatePermForRole(List<long> permIds, long roleId)
		{
			// delete perm not in list
			var oldPerm = dbContext.RolesPerms.Where(rp => !permIds.Contains(rp.PermId) && rp.RoleId == roleId);

			dbContext.RolesPerms.RemoveRange(oldPerm);

			foreach(var permId in permIds) {
				var rolePerm = dbContext.RolesPerms.FirstOrDefault(rp => rp.PermId == permId && rp.RoleId == roleId);
				if(rolePerm == null)
				{
					dbContext.RolesPerms.Add(new RolesPerms
					{
						RoleId = roleId,
						PermId = permId
					});
				}
			}

			dbContext.SaveChanges();
			var newPermList = dbContext.Roles.Include(r => r.RolesPerms)
							.ThenInclude(rp => rp.Perm)
							.Select(u => UserRule.GetPerm(u))
							.ToList();
			return newPermList;
		}

	}
}
