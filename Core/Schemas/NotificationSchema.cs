using System.ComponentModel.DataAnnotations.Schema;
using static Core.Business.NotifRule;

namespace Core.Schemas
{
    public class NotificationSchema: BaseSchema
    {
        public NotificationType Type { get; set; }
        public string Content { get; set; }
        public long SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public UserSchema User { get; set; } 
        public int? PostId { get; set; } 
        public long? TargetUserId { get; set; }
    }
}
