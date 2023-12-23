using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business
{
	public class GroupRule
	{
		public enum RoleUser
		{
			ADMIN = 1,
			CENSOR = 2,
			MEMBER = 3,
		}

		public enum GroupStatus
		{
			INACTIVE = 1,
			ACTIVE = 2,
		}

		public enum MemberStatus
		{
			PENDING = 1,
			ACCEPTED = 2
		}
	}
}
