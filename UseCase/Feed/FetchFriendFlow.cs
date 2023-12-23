using Core.Models;
using Core;
using Core.Constant;
using Core.Business;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Feed
{
    public class FetchFriendFlow : BaseFlow
    {
        public FetchFriendFlow(DataContext dbContext) : base(dbContext) { }

        public async Task<ResponseModel> Execute(long userId)
        {
            var friends = await (from u in dbContext.Users
                           where u.Id == userId
                           join friend in dbContext.UserFriends on u.Id equals friend.SourceId
                           where friend.Status == UserRule.FriendStatus.ACCEPTED
                           select u).ToListAsync();
            return new ResponseModel(GlobalVariable.SUCCESS, friends);
        }
    }
}
