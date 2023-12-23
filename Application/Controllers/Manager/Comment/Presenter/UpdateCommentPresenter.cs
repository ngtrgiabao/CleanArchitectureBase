using System.ComponentModel.DataAnnotations;

namespace Application.Controllers.Manager.Comment.Presenter
{
    public class UpdateCommentPresenter
    {
        public string? Content { get; set; }
        public string? Link { get; set; }
        public string[]? Images { get; set; }
        [Required]
        [MinLength(1)]
        public long UserId { get; set; }
    }
}
