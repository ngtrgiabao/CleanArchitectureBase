using Core.Interfaces;
using Core.Schemas;
using Core;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Core.Business;
using System.Data;

namespace Infrastructure.Services
{
    public class UserService : BaseService<UserSchema, DataContext>, IUserService
    {
        public UserService(DataContext _ctx) : base(_ctx)
        { }

		

		public UserRoleModel FindUserRole(long id)
        {
            UserRoleModel userPermModel = dbContext.Users
                .Where(u => u.Id == id)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                        .ThenInclude(r => r.RolesPerms)
                            .ThenInclude(rp => rp.Perm)
                .Select(u => UserRule.GetUserRole(u))
                .FirstOrDefault();

            return userPermModel;
        }

		public List<UserRoleModel> GetUsersWithRoles()
		{
			var usersWithRoles = dbContext.Users.Include(u => u.UserRoles)
				                                .ThenInclude(ur => ur.Role)
						                                .ThenInclude(r => r.RolesPerms)
							                                .ThenInclude(rp => rp.Perm) 
				                                .Select(u => UserRule.GetUserRole(u))
                                                .ToList();

			return usersWithRoles;
		}
		public UserSchema GetByEmail(string email)
        {
            return dbContext.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
        }

        public void UpdateAfterLogin(long userId, string refreshToken)
        {
            UserSchema? u = dbContext.Users.Find(userId);
            if (u != null)
            {
                u.HashRefreshToken = refreshToken;
                u.LastLogin = DateTime.UtcNow;
                dbContext.SaveChanges();
            }

        }
    }
}
