using static Core.Business.PostRule;

namespace Core.Models.Manager.Post
{
    public class CreatePostModel
    {
        public string Content { get; set; }
        public PostType Type { get; set; }
        public string[] Images { get; set; }
        public int UserId { get; set; }
        public int AccessModify { get; set; }
    }
}
