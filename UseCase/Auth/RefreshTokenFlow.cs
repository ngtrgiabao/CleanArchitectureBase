using Core.Interfaces;
using Core.Models;
using Core.Models.AuthModel;
using Core.Schemas;
using System.IdentityModel.Tokens.Jwt;
using Core.Constant;

namespace UseCase.Auth
{
    public class RefreshTokenFlow
    {
        private readonly IUserService userService;
        public RefreshTokenFlow(IUserService _userService)
        {
            userService = _userService;
        }

        public async Task<ResponseModel> Execute(TokenModel model, byte[] secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(model.AccessToken);
            var userCredentialString = jwtToken.Claims.First(x => x.Type == "id").Value;
            long userId = long.Parse(userCredentialString);
            UserSchema u = await userService.Get(userId);

			bool isMatched = u.HashRefreshToken.Equals(model.RefreshToken);
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
