using Core.Interfaces;
using Core.Models;
using Core.Models.AuthModel;
using Core.Schemas;
using Core.Constant;

namespace UseCase.Auth
{
    public class LoginFlow
    {
        private readonly IUserService userService;
        public LoginFlow(IUserService _userService)
        {
            userService = _userService;
        }
         
        public ResponseModel Execute(LoginModel model, byte[] secretKey)
        {
            UserSchema user = userService.GetByEmail(model.Email);
            if (user == null)
            {
                return new ResponseModel(GlobalVariable.ERROR, new { });
            } 
            bool isMatched = JwtUtil.Compare(model.Password, user.Password);
            if (!isMatched)
            {
                return new ResponseModel(GlobalVariable.ERROR, new { });
            }
            UserRoleModel userPerm = userService.FindUserRole(user.Id);
            string accessToken = JwtUtil.GenerateAccessToken(userPerm, secretKey);
            string refreshToken = JwtUtil.GenerateRefreshToken();
            userService.UpdateAfterLogin(user.Id, refreshToken);
            return new ResponseModel(GlobalVariable.SUCCESS, new { AccessToken = accessToken, RefreshToken = refreshToken, User = userPerm });
        }
    }
}
