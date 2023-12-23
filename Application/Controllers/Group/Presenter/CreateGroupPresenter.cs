using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Group.Presenter
{
	public class CreateGroupPresenter
	{

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

    }
}
