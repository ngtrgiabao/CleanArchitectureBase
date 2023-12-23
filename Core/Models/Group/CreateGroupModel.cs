using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.Business.GroupRule;

namespace Core.Models.Group
{
    public class CreateGroupModel
    {
		public string Name { get; set; }
		public long CreatedBy { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Slug { get; set; }
        public string Summary { get; set; }
        public GroupStatus Status { get; set; } 
        public string Profile { get; set; }
        public string Content { get; set; }
    }
}
