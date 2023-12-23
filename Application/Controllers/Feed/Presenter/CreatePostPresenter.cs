using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Feed.Presenter
{
    public class CreatePostPresenter
    {
        [Required]
        [MaxLength(500)]
        public string? Content { get; set; }
        public string[]? Images { get; set; }
        [Required]
        [MinLength(1)]
        public int? UserId { get; set; }
        [Required]
        public int AccessModify { get; set; }
    }
}
