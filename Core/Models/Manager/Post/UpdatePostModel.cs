namespace Core.Models.Manager.Post
{
    public class UpdatePostModel
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public string[] Images { get; set; }
        public int AccessModify { get; set; }
    }
}
