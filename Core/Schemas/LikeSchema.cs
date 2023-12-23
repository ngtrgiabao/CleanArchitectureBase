using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas
{
    public class LikeSchema: BaseSchema
    {
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public LikeTypeSchema Type { get; set; }

        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public UserSchema Liker { get; set; }

        public long PostId { get; set; }
        [ForeignKey("PostId")]
        public PostSchema Post { get; set; }
    }
}
