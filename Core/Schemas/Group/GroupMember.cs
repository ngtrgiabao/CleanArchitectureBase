using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Schemas.User;

namespace Core.Schemas
{
    public class GroupMember: BaseSchema
    { 

        [Required]
        public long GroupId { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        public short Type { get; set; } = 0;

        public short Status { get; set; } = 0; 

        public string Notes { get; set; }

        [ForeignKey("GroupId")]
        public GroupSchema Group { get; set; }

        [ForeignKey("UserId")]
        public UserSchema User { get; set; }
    }
}
