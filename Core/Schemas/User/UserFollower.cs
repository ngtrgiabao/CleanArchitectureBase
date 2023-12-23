using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Core.Schemas.User;

namespace Core.Schemas
{
    public class UserFollower : BaseSchema
    { 
        public long SourceId { get; set; }
         
        public long TargetId { get; set; }

        [Required]
        public short Type { get; set; } = 0;

        [ForeignKey("SourceId")]
        public UserSchema UserSource { get; set; }

        [ForeignKey("TargetId")]
        public UserSchema UserTarget { get; set; }
    }
}
