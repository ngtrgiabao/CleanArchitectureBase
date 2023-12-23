using Core.Models;
using Core.Schemas; 
namespace Core.Interfaces
{
    public interface IRoleService : IBaseService<RoleSchema>
    {
        RoleSchema GetRoleByTitle(string title);
		List<RolePermModel> GetRolesWithPerms();
		List<RolePermModel> UpdatePermForRole(List<long> permIds, long roleId);
		void AddRolesToUser(List<long> roleIds, long userId);


	}
}
