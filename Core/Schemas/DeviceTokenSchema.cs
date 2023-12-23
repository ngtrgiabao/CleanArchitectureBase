using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas
{
    public class DeviceTokenSchema : BaseSchema
    {
        public string ConnectionId { get; set; }
        public long UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserSchema User { get; set; }

    }
}
