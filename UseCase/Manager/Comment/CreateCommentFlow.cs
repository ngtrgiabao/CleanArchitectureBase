using Core.Constant;
using Core.Interfaces;
using Core.Models;
using Core.Models.Comment;
using Core.Schemas;
using static Core.Business.CommentRule;

namespace UseCase.Manager.Comment
{
    public class CreateCommentFlow
    {
        private readonly ICommentService _commentService;
        public CreateCommentFlow(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<ResponseModel> Excute(CommentOnPostModel model)
        {
            model.CommenterId = model.UserId;
            CommentSchema comment = new CommentSchema
            {
                Content = model.Content,
                Images = model.Images,
                Link = model.Link,
                PostId = model.PostId,
                Type = model.Content != null ? CommentType.TEXT : CommentType.IMAGE,
                UserId = model.CommenterId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            await _commentService.Add(comment);
            return new ResponseModel(GlobalVariable.SUCCESS, comment);
        }
    }
}
