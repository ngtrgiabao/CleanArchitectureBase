using Core.Models;
using Core;
using Core.Constant;

namespace UseCase.Feed
{
    public class FetchProMemberFlow : BaseFlow
    {
        public FetchProMemberFlow(DataContext dbContext) : base(dbContext)
        {
        }
        public ResponseModel Execute()
        {
            return new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
