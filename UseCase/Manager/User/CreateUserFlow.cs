using Core;
using Core.Constant;
using Core.Interfaces;
using Core.Models.AuthModel;
using Core.Models;
using Core.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models.Manager.User;

namespace UseCase.Manager.User
{
    public class CreateUserFlow
    {
        private readonly IUserService userService;
		private readonly IRoleService roleService;

		public CreateUserFlow(IUserService _userService, IRoleService _roleService)
        {
            userService = _userService;
			roleService = _roleService;
		}

		public async Task<ResponseModel> Execute(CreateUserModel model)
        {
            UserSchema userExist = userService.GetByEmail(model.Email);
            if (userExist != null)
            {
                return new ResponseModel(GlobalVariable.ERROR, new { });
            }
            UserSchema user = new UserSchema
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Mobile = model.Mobile,
                Gender = model.Gender,
                Relationship = model.Relationship,
                Bio = model.Bio,
                Avatar = model.Avatar,
                Background = model.Background,
                Status = model.Status,
                Dob = model.Dob,
                ProvinceId = model.ProvinceId,
                DistrictId = model.DistrictId,
                WardId = model.WardId,
                Password = JwtUtil.MD5Hash(model.Password),
                CreatedAt = DateTime.UtcNow
            };
            await userService.Add(user);
            userService.ClearTracker();
            roleService.AddRolesToUser(model.RoleIds, user.Id);

            user.Password = ""; // not response password hash
            return new ResponseModel(GlobalVariable.SUCCESS, user);
        }
    }
}
