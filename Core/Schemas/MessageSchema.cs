using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Schemas
{
    public class MessageSchema : BaseSchema
    {
        [Required]
        public long SenderId { get; set; }

        [Required]
        public long ReceiverId { get; set; }

        public string Content { get; set; }

        [ForeignKey("SenderId")]
        public UserSchema Sender { get; set; }

        [ForeignKey("ReceiverId")]
        public UserSchema Receiver { get; set; }
    }
}
