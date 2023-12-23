using Core;
using Core.Models;
using Core.Constant;

namespace UseCase.Group
{
    public class FetchCategoryFlow : BaseFlow
    {
        public FetchCategoryFlow(DataContext dbContext) : base(dbContext)
        {
        }
        public async Task<ResponseModel> Execute()
        {
            return new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
