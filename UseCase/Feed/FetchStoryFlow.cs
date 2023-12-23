using Core.Models;
using Core;
using Core.Constant;
using Core.Schemas;
using Core.Business;

namespace UseCase.Feed
{
    public class FetchStoryFlow : BaseFlow
    {
        public FetchStoryFlow(DataContext dbContext) : base(dbContext)
        {
        }
        public ResponseModel Execute(long userId)
        {
            var story = (from p in dbContext.Posts
                         join u in dbContext.Users on p.UserId equals u.Id
                         join f in dbContext.UserFriends on u.Id equals f.SourceId
                         where p.Type == PostRule.PostType.STORY && u.Id == userId
                         select new PostSchema()
                         {
                             Id = p.Id,
                             Images = p.Images,
                             Content = p.Content,
                             Poster = p.Poster
                         }).ToList();
            return new ResponseModel(GlobalVariable.SUCCESS, null);
        }
    }
}
