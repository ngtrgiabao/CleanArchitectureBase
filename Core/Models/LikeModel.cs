 

namespace Core.Models
{
    public class LikeModel
    {
        public int LikeTypeId { get; set; }
        public long PostId { get; set; }
        public long LikerId { get; set; }
    }
}
