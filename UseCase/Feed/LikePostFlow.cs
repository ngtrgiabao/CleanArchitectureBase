using Core.Constant; 
using Core.Models;
using Core.Schemas;
using Core;
namespace UseCase.Feed
{
    public class LikePostFlow: BaseFlow
    {
        public LikePostFlow(DataContext dbContext) : base(dbContext) { }

        public async Task<ResponseModel> Execute(LikeModel model)
        {
            LikeSchema like = new LikeSchema();
            like.PostId = model.PostId;
            like.TypeId = model.LikeTypeId;
            dbContext.Likes.Add(like);
            await dbContext.SaveChangesAsync();
            return new ResponseModel(GlobalVariable.SUCCESS, like);
        }
    }
}
