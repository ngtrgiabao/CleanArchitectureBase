using Core;
using Core.Interfaces;
using Core.Models;
using Core.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Core.Constant;
using Core.Business;

namespace Infrastructure.Services
{
	public class SeedDataService : ISeedService
	{
		DataContext dbContext;
		public SeedDataService(DataContext _ctx)
		{
			dbContext = _ctx;
		}

		public async Task<ResponseModel> Execute(List<RouterModel> routers)
		{
			ResponseModel response = new ResponseModel();
			var executionStrategy = dbContext.Database.CreateExecutionStrategy();

			await executionStrategy.Execute(async () =>
			{
				using IDbContextTransaction transaction = dbContext.Database.BeginTransaction();
				try
				{
					dbContext.Perms.RemoveRange(dbContext.Perms);
					dbContext.RolesPerms.RemoveRange(dbContext.RolesPerms);

					dbContext.SaveChanges();
					SeedRole();
					SeedUser();
					List<PermSchema> perms = await CreatePerms(routers);
					List<RoleSchema> roles = await CreateRolePerm(perms);
					AddUserToRole(roles);
					// SeedLikeType();
					response.Status = "success";
					response.Result = true;
					transaction.Commit();
				}
				catch (Exception ex)
				{
					response.Status = "error";
					response.Result = false;
					transaction.Rollback();
					throw;
				}
			});

			return response;
		}

		#region Private Function

		private async void SeedLikeType()
		{
			List<LikeTypeSchema> likeTypes = new();
			likeTypes.Add(new LikeTypeSchema() { Id = 1, Title = "Thích" });
			likeTypes.Add(new LikeTypeSchema() { Id = 1, Title = "Yêu thích" });
			likeTypes.Add(new LikeTypeSchema() { Id = 2, Title = "Ha ha" });
			likeTypes.Add(new LikeTypeSchema() { Id = 3, Title = "Buồn" });
			likeTypes.Add(new LikeTypeSchema() { Id = 4, Title = "Phẫn nộ" });
			await dbContext.LikeTypes.AddRangeAsync(likeTypes);
			await dbContext.SaveChangesAsync();
		}

		private async Task<List<RoleSchema>> CreateRolePerm(List<PermSchema> perms)
		{
			List<RoleSchema> roles = dbContext.Roles.ToList();
			List<RolesPerms> rolesPerms = new();
			foreach (var perm in perms)
			{
				foreach (var role in roles)
				{
					string roleValue = role.ProfileType.Replace("[", "").Replace("]", "");
					if (perm.ProfileTypes.Contains(roleValue) || perm.ProfileTypes == PermUtil.PUBLIC_PROFILE)
					{
						RolesPerms gp = new RolesPerms();
						gp.PermId = perm.Id;
						gp.RoleId = role.Id;
						rolesPerms.Add(gp);
					}
				}
			}
			await dbContext.RolesPerms.AddRangeAsync(rolesPerms);
			await dbContext.SaveChangesAsync();
			return roles;
		}

		private async Task<List<PermSchema>> CreatePerms(List<RouterModel> routers)
		{
			List<PermSchema> perms = new List<PermSchema>();
			foreach (var router in routers)
			{
				PermSchema permSchema = new PermSchema();
				permSchema.Action = HandleAction(router.Method);
				permSchema.Title = router.Method + " " + router.Path;
				permSchema.ProfileTypes = router.ProfileType;
				permSchema.Module = router.Path;
				perms.Add(permSchema);
			}
			await dbContext.Perms.AddRangeAsync(perms);
			await dbContext.SaveChangesAsync();
			return perms;
		}

		private string HandleAction(string method)
		{
			switch (method)
			{
				case "POST":
					return "CREATE";
				case "PUT":
					return "UPDATE";
				default:
					return method;
			}
		}

		private void AddUserToRole(List<RoleSchema> roles)
		{
			List<UsersRoles> usersRoles = new List<UsersRoles>();
			List<UserSchema> users = dbContext.Users.ToList();

			foreach (var user in users)
			{
				foreach (var role in roles)
				{
					if (user.RoleIds.Contains(role.ProfileType))
					{
						UsersRoles ug = new UsersRoles();
						ug.UserId = user.Id;
						ug.RoleId = role.Id;
						usersRoles.Add(ug);
					}
				}
			}
			dbContext.UsersRoles.AddRangeAsync(usersRoles);
			dbContext.SaveChanges();
		}

		private void SeedRole()
		{
			var ids = new long[] { 1, 2 };
			var currentGroups = dbContext.Users.Where(x => ids.Contains(x.Id)).ToList();
			if (currentGroups.Count == 0)
			{
				RoleSchema admin = new RoleSchema { Id = 1, Title = "Admin", Description = "", ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]" };
				RoleSchema staff = new RoleSchema { Id = 2, Title = "Staff", Description = "", ProfileType = "[" + PermUtil.STAFF_PROFILE + "]" };
				List<RoleSchema> roles = new List<RoleSchema> { admin, staff };
				dbContext.Roles.AddRangeAsync(roles);
				dbContext.SaveChanges();
			}
		}

		private void SeedUser()
		{
			var ids = new long[] { 1, 2 };
			var currentUsers = dbContext.Users.Where(x => ids.Contains(x.Id)).ToList();
			if (currentUsers.Count == 0)
			{
				string defaultPassword = JwtUtil.MD5Hash(UserRule.DEFAULT_PASSWORD);
				UserSchema userAdmin = new UserSchema { Id = 1, Password = defaultPassword, Email = "admin@gmail.com", RoleIds = "[" + PermUtil.ADMIN_PROFILE + "]" };
				UserSchema userStaff = new UserSchema { Id = 2, Password = defaultPassword, Email = "staff@gmail.com", RoleIds = "[" + PermUtil.STAFF_PROFILE + "]" };
				List<UserSchema> users = new List<UserSchema> { userAdmin, userStaff };
				dbContext.Users.AddRange(users);
				dbContext.SaveChanges();
			}

		}



		#endregion
	}


}
