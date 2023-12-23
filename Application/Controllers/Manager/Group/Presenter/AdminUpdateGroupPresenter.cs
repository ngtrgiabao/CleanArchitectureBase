using System.ComponentModel.DataAnnotations;
using static Core.Business.GroupRule;

namespace Application.Controllers.Manager.Group.Presenter
{
	public class AdminUpdateGroupPresenter
	{
		[Required]
		public long Id { get; set; }

		[Required]
		[StringLength(20)]
		public string Name { get; set; } = "";

        [Required]
		[StringLength(75)]
		public string Title { get; set; } = "";

        [StringLength(100)]
		public string MetaTitle { get; set; } = "";
        public string Summary { get; set; } = "";

        public string Profile { get; set; } = "";

        public string Content { get; set; } = "";
        public GroupStatus Status { get; set; } 
	}
}
