using Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web;
namespace Core.Constant
{
    public static class JwtUtil
    {
        public static string GenerateAccessToken(UserRoleModel user, byte[] secretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var userIdClaim = new Claim("id", user.Id.ToString());
            var nameClaim = new Claim("name", user.Fullname);

            var permClaims = user.Roles.Select(role =>
                new Claim("perms", $"{string.Join(",", role.Perms.Select(perm => perm))}")
            );

            var claims = new List<Claim> { userIdClaim, nameClaim };
            claims.AddRange(permClaims);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public static string MD5Hash(string input)
        {
            StringBuilder hash = new();
            MD5CryptoServiceProvider md5provider = new();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }


        public static int GetRefreshTokenExpiryTime()
        {
            var refreshTokenExpiryDate = DateTime.Now.AddDays(7);
            return DateTimeToUnixTimeStamp(refreshTokenExpiryDate);
        }

        public static int DateTimeToUnixTimeStamp(DateTime dateTime)
        {
            DateTime localDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTime, TimeUtil.TIMEZONE_ID.GMT0);
            int unixTimestamp = (int)(localDateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return unixTimestamp;
        }

        public static string Encode(string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        public static string Decode(string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        public static bool Compare(string password, string userPassword)
        {
            string hash = MD5Hash(password);
            return hash.ToLower().Equals(userPassword.ToLower());
        }

        public static string GetUserIdFromAccessToken(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();

            if (handler.CanReadToken(accessToken))
            {
                var jsonToken = handler.ReadToken(accessToken) as JwtSecurityToken;
                var userId = jsonToken?.Payload["id"]?.ToString();
                return userId;
            }
            return null;
        }

        public static (int UserId, List<string> Perms) GetUserInfoInToken(byte[] key, string accessToken)
        {
            string token = accessToken.Replace("Bearer ", "");
            var tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters tokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };
            tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
             
            var userCredentialString = jwtToken.Claims.First(x => x.Type == "id").Value;
            int userId = Int32.Parse(userCredentialString); 
             
            var permsClaim = jwtToken.Claims.FirstOrDefault(x => x.Type == "perms");
            List<string> perms = permsClaim?.Value?.Split(',')?.ToList() ?? new List<string>();

            return (UserId: userId, Perms: perms);
        }
    }
}
