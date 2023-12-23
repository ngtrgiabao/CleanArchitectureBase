using Core.Constant;
using System.Text;

namespace Application.Helpers
{
    public class Common
    {
        public static long GetCurrentUserId(HttpContext httpContext)
        {
            var configuration = httpContext.RequestServices.GetRequiredService<IConfiguration>();
            var secretKey = configuration["Configuration:SecretKey"];
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            string accessToken = httpContext.Request.Headers["Authorization"].FirstOrDefault();
            var userInfo = JwtUtil.GetUserInfoInToken(key, accessToken);
            return userInfo.UserId;
        }

        public static string SetPermission(params int[] permissions)
        {
            return "[" + string.Join(",", permissions) + "]";
        }
    }
}
