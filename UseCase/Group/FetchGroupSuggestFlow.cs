using Core.Models;
using Core.Constant;
using Core;

namespace UseCase.Group
{
    public class FetchGroupSuggestFlow : BaseFlow
    {
        public FetchGroupSuggestFlow(DataContext dbContext) : base(dbContext)
        {
        }

        public Task<ResponseModel> Execute()
        {
            return null;//new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
