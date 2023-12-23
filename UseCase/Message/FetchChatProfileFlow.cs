using Core;
using Core.Models;
using Core.Constant;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Message
{
    public class FetchChatProfileFlow : BaseFlow
    {
        public FetchChatProfileFlow(DataContext dbContext) : base(dbContext) { }
        public async Task<ResponseModel> Execute(long userId)
        {
            var profile = await (from u in dbContext.Users
                                 where u.Id == userId
                                 select new
                                 {
                                     u.Id,
                                     u.IsOnline,
                                     u.Avatar,
                                     DisplayName = u.FirstName + " " + u.LastName,
                                     Username = u.FirstName + " " + u.LastName,
                                 }).FirstOrDefaultAsync();

            return new ResponseModel(GlobalVariable.SUCCESS, profile);
        }
    }
}
