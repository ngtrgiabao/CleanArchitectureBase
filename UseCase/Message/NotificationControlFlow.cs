using Core.Models;
using Core;
using Core.Constant;

namespace UseCase.Message
{
    public class NotificationControlFlow : BaseFlow
    {
        public NotificationControlFlow(DataContext dbContext) : base(dbContext) { }
        public Task<ResponseModel> Execute()
        {
            return null;//new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
