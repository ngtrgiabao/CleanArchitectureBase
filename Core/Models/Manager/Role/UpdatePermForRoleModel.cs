using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Manager.Role
{
	public class UpdatePermForRoleModel
	{
		public long RoleId {  get; set; }
		public List<long> PermIds { get; set; }
	}
}
