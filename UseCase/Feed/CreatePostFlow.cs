using Core.Models;
using Core;
using Core.Constant;
using Core.Models.Feed;
using Core.Schemas;
using Core.Business;

namespace UseCase.Feed
{
    public class CreatePostFlow : BaseFlow
    {
        public CreatePostFlow(DataContext dbContext) : base(dbContext) { }

        public async Task<ResponseModel> Execute(PostModel model)
        {
            PostSchema post = new PostSchema();
            post.Content = model.Content;
            post.CreatedAt = DateTime.UtcNow;
            post.Type = (PostRule.PostType)FeedRule.GetPostType(model);
            post.UserId = model.UserId;
            post.AccessModify = model.AccessModify;
            await dbContext.Posts.AddAsync(post);
            await dbContext.SaveChangesAsync();
            post.Likes = new List<LikeSchema>();
            post.Comments = new List<CommentSchema>();
            post.Poster = dbContext.Users.FirstOrDefault(x => x.Id == model.UserId);
            var result = FeedRule.GetPost(post);
            return new ResponseModel(GlobalVariable.SUCCESS, result);
        }
    }
}
