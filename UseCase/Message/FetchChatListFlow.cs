using Core;
using Core.Models;
using Core.Constant;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Message
{
    class ChatUser
    {
        public string AvatarUrl { get; set; }
        public long Id { get; set; }
        public bool IsOnline { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageTime { get; set; }
        public string Name { get; set; }
        public int UnreadMessageCount { get; set; }
    }

    public class FetchChatListFlow : BaseFlow
    {
        public FetchChatListFlow(DataContext dbContext) : base(dbContext) { }
        public async Task<ResponseModel> Execute(string userName, long currentId)
        {
            //var chatList = await (from us in dbContext.UserMessages
            //                      join u in dbContext.Users on us.SourceId equals u.Id
            //                      where (u.FirstName + u.LastName).Contains(userName)
            //                            && us.TargetId == currentId
            //                      select new
            //                      {
            //                          u.Id,
            //                          u.IsOnline,
            //                          Avartar = u.Avatar,
            //                          DisplayName = u.FirstName + " " + u.LastName,
            //                          UserName = u.FirstName + " " + u.LastName,
            //                      }).ToListAsync();

            List<ChatUser> chatUsers = new List<ChatUser>
            {
                new ChatUser
                {
                    AvatarUrl = "https://avatars.githubusercontent.com/u/37137230",
                    Id = 2,
                    IsOnline = true,
                    LastMessage = "Cultura velut cunae cubitum coerceo mollitia aspicio colligo perspiciatis.",
                    LastMessageTime = DateTime.UtcNow,
                    Name = "Maryam",
                    UnreadMessageCount = 0
                },
                new ChatUser
                {
                    AvatarUrl = "https://cloudflare-ipfs.com/ipfs/Qmd3W5DuhgHirLHGVixi6V76LhCkZUz6pnFt5AJBiyvHye/avatar/319.jpg",
                    Id =3,
                    IsOnline = false,
                    LastMessage = "Amissio vulnus tricesimus et depulso ciminatio varietas adfero spoliatio conatus.",
                    LastMessageTime = DateTime.UtcNow,
                    Name = "Josianne",
                    UnreadMessageCount = 0
                }

            };

            return new ResponseModel(GlobalVariable.SUCCESS, chatUsers);
        }
    }
}
