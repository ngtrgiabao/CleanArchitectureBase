using Core.Constant;
using Core.Interfaces;
using Core.Models;
using Core.Models.Comment;
using Core.Schemas;

namespace UseCase.Manager.Comment
{
    public class UpdateCommentFlow
    {
        private readonly ICommentService _commentService;
        public UpdateCommentFlow(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ResponseModel> Excute(UpdateCommentOnPostModel model, long id)
        {

            CommentSchema comment = await _commentService.Get(id);

            comment.Content = model.Content;
            comment.Images = model.Images;
            comment.Link = model.Link;
            comment.UpdatedAt = DateTime.UtcNow;

            await _commentService.Update(comment);
            return new ResponseModel(GlobalVariable.SUCCESS, comment);
        }
    }
}
