
using System.ComponentModel.DataAnnotations.Schema;
using static Core.Business.CommentRule;

namespace Core.Schemas
{
    public class CommentSchema : BaseSchema
    {
        public string? Content { get; set; }
        public string? Link { get; set; }
        public string[]? Images { get; set; }
        public CommentType Type { get; set; }
        public long PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public PostSchema Post { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserSchema Commenter { get; set; }
    }
}
