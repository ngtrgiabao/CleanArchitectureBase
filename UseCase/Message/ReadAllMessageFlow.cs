using Core.Models;
using Core;
using Core.Constant;

namespace UseCase.Message
{
    public class ReadAllMessageFlow : BaseFlow
    {
        public ReadAllMessageFlow(DataContext dbContext) : base(dbContext) { }
        public Task<ResponseModel> Execute()
        {
            return null;//new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
