using Core.Constant;
using Core.Interfaces;
using Core.Models.Manager.Post;
using Core.Models;
using Core.Schemas;


namespace UseCase.Manager.Post
{
    public class UpdatePostFlow
    {
        private readonly IPostService _postService;
        public UpdatePostFlow(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<ResponseModel> Excute(UpdatePostModel model, long id)
        {

            PostSchema post = await _postService.Get(id);

            post.Content = model.Content;
            post.Images = model.Images;
            post.AccessModify = model.AccessModify;
            post.UpdatedAt = DateTime.UtcNow;

            await _postService.Update(post);
            return new ResponseModel(GlobalVariable.SUCCESS, post);
        }
    }
}
