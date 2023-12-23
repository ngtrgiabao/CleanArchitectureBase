using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Group.Presenter
{
	public class UpdateGroupPresenter
	{
		[Required]
		public long Id { get; set; }

		[StringLength(20)]
		public string Name { get; set; } = "";

        [StringLength(75)]
		public string Title { get; set; } = "";

        [StringLength(100)]
		public string MetaTitle { get; set; } = "";
        public string Summary { get; set; } = "";

        public string Profile { get; set; } = "";


        public string Content { get; set; } = "";
    }
}
