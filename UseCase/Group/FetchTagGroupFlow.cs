using Core.Models;
using Core.Constant;
using Core;

namespace UseCase.Group
{
    public class FetchTagGroupFlow : BaseFlow
    {
        public FetchTagGroupFlow(DataContext dbContext) : base(dbContext) { }

        public Task<ResponseModel> Execute()
        {
            return null;//new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
