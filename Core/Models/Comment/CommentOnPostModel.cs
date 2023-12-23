namespace Core.Models.Comment
{
    public class CommentOnPostModel
    {
        public string? Content { get; set; }
        public string? Link { get; set; }
        public string[]? Images { get; set; }
        public long PostId { get; set; }
        public long UserId { get; set; }
        public long CommenterId { get; set; }
    }
}
