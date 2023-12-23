namespace Core.Models.SignalR
{
    public class BaseSignalRModel
    {
        public long SenderId { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
    }
}
