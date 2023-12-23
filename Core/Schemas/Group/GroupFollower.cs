using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Schemas.User;

namespace Core.Schemas
{
    public class GroupFollower: BaseSchema
    { 
        [Required]
        public long GroupId { get; set; }

        [Required]
        public long UserId { get; set; }

        [ForeignKey("GroupId")]
        public GroupSchema Group { get; set; }

        [ForeignKey("UserId")]
        public UserSchema User { get; set; }
    }
}
