using Core.Constant;
using Core.Interfaces;
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
    public class UpdateUserFlow
    {
        private readonly IUserService userService;
		private readonly IRoleService roleService;

		public UpdateUserFlow(IUserService _userService, IRoleService _roleService)
        {
            userService = _userService;
			roleService = _roleService;

		}
		public async Task<ResponseModel> Execute(UpdateUserModel model)
        {
            UserSchema user = userService.GetByEmail(model.Email);
            if (user == null)
            {
                return new ResponseModel(GlobalVariable.ERROR, new { });
            }

            user.Email = model.Email;
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Mobile = model.Mobile;
            user.Gender = model.Gender;
            user.Relationship = model.Relationship;
            user.Bio = model.Bio;
            user.Avatar = model.Avatar;
            user.Background = model.Background;
            user.Status = model.Status;
            user.Dob = model.Dob;
            user.ProvinceId = model.ProvinceId;
            user.DistrictId = model.DistrictId;
            user.WardId = model.WardId;
            user.Password = JwtUtil.MD5Hash(model.Password);
            user.UpdatedAt = DateTime.UtcNow;
			await userService.Update(user);
			userService.ClearTracker();

			roleService.AddRolesToUser(model.RoleIds, user.Id);

			user.Password = ""; // not response hashpassword 
            return new ResponseModel(GlobalVariable.SUCCESS, user);
        }
    }
}
