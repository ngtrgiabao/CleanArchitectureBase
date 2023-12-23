using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Business.GroupRule;

namespace Core.Models.Manager.Group
{
	public class AdminUpdateGroupModel
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public long UpdatedBy { get; set; }
		public string Title { get; set; }
		public string MetaTitle { get; set; }
		public string Summary { get; set; }
		public string Profile { get; set; }
		public string Content { get; set; }
		public GroupStatus Status { get; set; }
	}
}
