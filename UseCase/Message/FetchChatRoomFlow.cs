using Core;
using Core.Models;
using Core.Constant;
using Microsoft.EntityFrameworkCore;
using Core.Business;

namespace UseCase.Message
{
    public class FetchChatRoomFlow : BaseFlow
    {
        public FetchChatRoomFlow(DataContext dbContext) : base(dbContext) { }
        public async Task<ResponseModel> Execute(long currentUserId, long userId, string startTime, string endTime)
        { 

            var chatRoom = await (from m in dbContext.Messages
                              where m.SenderId == currentUserId && m.ReceiverId == userId
                              join media in dbContext.Medias on m.Id equals media.MessageId into mediaGroup
                              select ChatRule.GetChatRoom(m, mediaGroup, currentUserId)).ToListAsync();

            return new ResponseModel(GlobalVariable.SUCCESS, chatRoom);
        }
    }
}
