using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas.User
{
    public class UserSetting: BaseSchema
    {
        [Required]
        public long UserId { get; set; }
        [ForeignKey("UserId")]
        public UserSchema User { get; set; }
    }
}
