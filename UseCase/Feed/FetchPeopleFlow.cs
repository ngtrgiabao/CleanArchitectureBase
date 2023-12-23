using Core.Models;
using Core;
using Core.Constant;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Feed
{
    public class FetchPeopleFlow : BaseFlow
    {
        public FetchPeopleFlow(DataContext dbContext) : base(dbContext) { }
        public async Task<ResponseModel> Execute()
        {
            var people = await dbContext.Users.ToListAsync();
            return new ResponseModel(GlobalVariable.SUCCESS, people);
        }
    }
}
