using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static Core.Business.UserRule;

namespace Core.Schemas
{
    public class UserFriend : BaseSchema
    {

        [Required]
        public long SourceId { get; set; }

        [Required]
        public long TargetId { get; set; }

        [Required]
        public FriendStatus Status { get; set; }

        [ForeignKey("SourceId")]
        public UserSchema UserSource { get; set; }

        [ForeignKey("TargetId")]
        public UserSchema UserTarget { get; set; }
    }
}
