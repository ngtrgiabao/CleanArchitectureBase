using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Schemas.User;

namespace Core.Schemas
{
    public class GroupPost: BaseSchema
    {
        [Required]
        public long GroupId { get; set; }

        [Required]
        public long UserId { get; set; }

        public string Message { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("GroupId")]
        public GroupSchema Group { get; set; }

        [ForeignKey("UserId")]
        public UserSchema User { get; set; }
    }
}
