namespace Application.Controllers.Comment.Presenter
{
    public class CommentOnPostPresenter
    {
        public string? Content { get; set; }
        public string? Link { get; set; }
        public string[]? Images { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
    }
}
