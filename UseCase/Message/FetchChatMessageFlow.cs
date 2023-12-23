using Core.Models;
using Core;
using Core.Constant;

namespace UseCase.Message
{
    public class FetchChatMessageFlow : BaseFlow
    {
        public FetchChatMessageFlow(DataContext dbContext) : base(dbContext) { }
        public Task<ResponseModel> Execute()
        {
            return null; // new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
