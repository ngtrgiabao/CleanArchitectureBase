using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class RolePermModel
	{
		public long Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public List<PermModel> Perms { get; set; }
	}
}
