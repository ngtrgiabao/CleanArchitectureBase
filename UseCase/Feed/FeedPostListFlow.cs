using Core;
using Core.Business;
using Core.Constant;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace UseCase.Feed
{
    public class FeedPostListFlow : BaseFlow
    {
        public FeedPostListFlow(DataContext dbContext) : base(dbContext) { }

        public async Task<ResponseModel> Execute(long userId)
        {
            var posts = new List<object>();
            try
            {
                posts = await dbContext.Posts
                        .Include(x => x.Poster)
                        .Include(x => x.Comments)
                        .Include(x => x.Likes)
                        .Where(x => x.UserId == userId)
                        .OrderBy(x => x.CreatedAt)
                        .Select(post => FeedRule.GetPost(post))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return new ResponseModel(GlobalVariable.SUCCESS, posts);
        }
    }
}
