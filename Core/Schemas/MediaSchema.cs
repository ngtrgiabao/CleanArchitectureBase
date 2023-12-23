using System.ComponentModel.DataAnnotations.Schema; 

namespace Core.Schemas
{
    public class MediaSchema: BaseSchema
    {
        public int Type { get; set; }
        public string Link { get; set; }
        public long MessageId { get; set; }
        [ForeignKey(nameof(MessageId))]
        public MessageSchema Message { get; set; }

        public long SenderId { get; set; }
        [ForeignKey(nameof(SenderId))]
        public UserSchema Sender { get; set; }
    }
}
