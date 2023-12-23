 

namespace Core.Models.Message
{
    public class SendMessageModel
    {
        public long SendToId { get; set; }
        public string Content { get; set; }
        public long SenderId { get; set; }
    }
}
