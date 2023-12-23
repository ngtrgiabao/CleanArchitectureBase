namespace Core.Models.Feed
{
    public class PostModel
    {
        public string Content { get; set; }
        public string[] Images { get; set; }
        public long UserId { get; set; }
        public int AccessModify { get; set; }
    }
}
