using System.ComponentModel.DataAnnotations.Schema;
using static Core.Business.PostRule;

namespace Core.Schemas
{
    public class PostSchema : BaseSchema
    {
        public long? UserId { get; set; }
        public string? Content { get; set; }
        public string[]? Images { get; set; }
        public PostType Type { get; set; }
        public int? Status { get; set; }
        public int AccessModify { get; set; }

        [ForeignKey("UserId")]
        public UserSchema Poster { get; set; }

        public List<CommentSchema>? Comments { get; set; }
        public List<LikeSchema>? Likes { get; set; }
    }
}
