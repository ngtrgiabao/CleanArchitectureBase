using Core.Schemas; 

namespace Core.Business
{
    public class ChatRule
    {
        public static object GetChatRoom(MessageSchema m, IEnumerable<MediaSchema> mediaGroup, long currentUserId)
        {
            return new
            {
                m.Id,
                IsMe = m.SenderId == currentUserId,
                m.Content,
                m.CreatedAt,
                m.UpdatedAt,
                Sender = UserRule.GetSender(m.Sender),
                MediaList = mediaGroup.Select(media => new
                {
                    media.Id,
                    media.Type,
                    media.Link,
                    Sender = UserRule.GetSender(media.Sender)
                }).ToList()
            };
        }
    }
}
