using Core.Models;
using Core.Schemas;

namespace Core.Interfaces
{
    public interface IUserService : IBaseService<UserSchema>
    {
        void UpdateAfterLogin(long userId, string refreshToken);
        UserSchema GetByEmail(string email);
        UserRoleModel FindUserRole(long id);
		void ClearTracker();

		List<UserRoleModel> GetUsersWithRoles();

	}
}
