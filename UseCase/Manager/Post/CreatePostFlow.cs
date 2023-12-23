using Core.Business;
using Core.Constant;
using Core.Interfaces;
using Core.Models;
using Core.Models.Feed;
using Core.Schemas;

namespace UseCase.Manager.Post
{
    public class CreatePostFlow
    {
        private readonly IPostService _postService;
        public CreatePostFlow(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<ResponseModel> Excute(PostModel model)
        {
            PostSchema post = new PostSchema
            {
                Content = model.Content,
                Images = model.Images,
                AccessModify = model.AccessModify,
                UserId = model.UserId,
                Type = (PostRule.PostType)FeedRule.GetPostType(model),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };
            await _postService.Add(post);
            return new ResponseModel(GlobalVariable.SUCCESS, post);
        }
    }
}
