using Core.Interfaces;
using Core.Models;
using Core.Models.AuthModel;
using Core.Schemas;
using System.IdentityModel.Tokens.Jwt;
using Core.Constant;

namespace UseCase.Auth
{
    public class RegisterFlow
    {
        private readonly IUserService userService;
        public RegisterFlow(IUserService _userService)
        {
            userService = _userService;
        }

        public ResponseModel Execute(RegisterModel model)
        {
            UserSchema user = new UserSchema
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = JwtUtil.MD5Hash(model.Password),
                Email = model.Email,
                RoleIds = "[" + PermUtil.END_USER + "]",
                CreatedAt = DateTime.UtcNow
            };
            userService.Add(user);
            return new ResponseModel(GlobalVariable.SUCCESS, user);
        }

        public async Task<ResponseModel> Execute(string accessToken, string refreshToken, byte[] secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(accessToken);
            var userCredentialString = jwtToken.Claims.First(x => x.Type == "id").Value;
            long userId = long.Parse(userCredentialString);
            UserSchema u = await userService.Get(userId);
        
            bool isMatched = u.HashRefreshToken.Equals(refreshToken);
            if (!isMatched)
            {
                return new ResponseModel(GlobalVariable.ERROR, new { });
            }

            UserRoleModel userPerm = userService.FindUserRole(u.Id);
            var newToken = JwtUtil.GenerateAccessToken(userPerm, secretKey);
            var newRefreshToken = JwtUtil.GenerateRefreshToken();
            return new ResponseModel(GlobalVariable.SUCCESS, new
            {
                AccessToken = newToken,
                RefreshToken = newRefreshToken
            });

        }
    }
}
