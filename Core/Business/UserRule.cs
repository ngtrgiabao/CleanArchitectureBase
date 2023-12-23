using Core.Constant;
using Core.Models;
using Core.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Core.Business
{
    public class UserRule
    {
        public static int ADMIN_ID = 1;
        public static int STAFF_ID = 2;
        public static string DEFAULT_PASSWORD = "123456";

        public enum FriendStatus
        {
            PENDING = 1,
            ACCEPTED = 2
        }

        public static List<UserSchema> RemoveDefaultAccount(List<UserSchema> items)
        {
            return items.Where(item => item.Id != ADMIN_ID && item.Id != STAFF_ID).ToList();
        }

		public static List<UserRoleModel> RemoveDefaultAccount(List<UserRoleModel> items)
		{
			return items.Where(item => item.Id != ADMIN_ID && item.Id != STAFF_ID).ToList();
		}

		public static object GetSender(UserSchema user)
        {
            return new
            {
                DisplayName = user.FirstName + " " + user.LastName,
                username = user.FirstName + " " + user.LastName,
                user.Id,
                user.Avatar,
                user.IsOnline
            };
        }
        public static UserRoleModel GetUserRole(UserSchema u)
        {
            var data = new UserRoleModel
            {
                Id = u.Id,
                Fullname = u.FirstName + " " + u.LastName,
                LastName = u.LastName,
                FirstName = u.FirstName,
                Email = u.Email,
                Mobile = u.Mobile,
                Avatar = u.Avatar,
                Background = u.Background,
                Bio = u.Bio,
                DistrictId = u.DistrictId,
                ProvinceId = u.ProvinceId,
                WardId = u.WardId,
                Dob = u.Dob,
                Status = u.Status,
                IsOnline = u.IsOnline,
                Gender = u.Gender,
                Relationship = u.Relationship,
                Roles = u.UserRoles
                  .Where(ur => ur.UserId == u.Id)
                  .Select(ur => new RoleModel
                  {
                      Id = ur.Role.Id,
                      Title = ur.Role.Title,
                      Perms = ur.Role.RolesPerms
                          .Where(rp => rp.Perm.ProfileTypes != PermUtil.PUBLIC_PROFILE)
                          .SelectMany(rp => rp.Perm.Title.Split(','))
                          .Distinct()
                          .ToList()
                  })
                  .DistinctBy(r => r.Id)
                  .ToList()
            };
            return data;
        }


		public static RolePermModel GetPerm(RoleSchema r)
		{
            var data = new RolePermModel
			{
                Id = r.Id,
                Title = r.Title,
				Perms = r.RolesPerms.Where(rp => rp.Perm.ProfileTypes != PermUtil.PUBLIC_PROFILE)
						  .Select(rp => new PermModel
                          {
                              Id = rp.Perm.Id,
                              Title = rp.Perm.Title,
                          })
						  .Distinct()
						  .ToList()
			};
	      return data;
		}
	}
}
