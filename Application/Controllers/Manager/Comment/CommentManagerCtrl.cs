using Application.Controllers.Comment.Presenter;
using Application.Controllers.Manager.Comment.Presenter;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Interfaces;
using Core.Models.Comment;
using Core.Schemas;
using Infrastructure.Services;
using UseCase.Manager.Comment;

namespace Application.Controllers.Manager.Comment
{
    public class CommentManagerCtrl
    {
        private readonly IMapper _mapper;
        private readonly ICommentService commentService;
        private readonly CreateCommentFlow createCommentFlow;
        private readonly UpdateCommentFlow updateCommentFlow;

        public CommentManagerCtrl(IMapper mapper, DataContext ctx)
        {
            _mapper = mapper;
            commentService = new CommentService(ctx);
            createCommentFlow = new CreateCommentFlow(commentService);
            updateCommentFlow = new UpdateCommentFlow(commentService);
        }

        public async Task<IResult> GetCommentById(long id)
        {
            CommentSchema existingComment = await commentService.Get(id);

            if (existingComment == null)
            {
                return Results.BadRequest("Comment not found");
            }

            return Results.Ok(existingComment);
        }

        public async Task<IResult> Get()
        {
            var comments = await commentService.GetAll();
            var response = CommentPresenter.PresentList(comments);

            return Results.Ok(response);
        }

        public async Task<IResult> Create(CommentOnPostPresenter model)
        {
            CommentOnPostModel comment = _mapper.Map<CommentOnPostModel>(model);
            var response = await createCommentFlow.Excute(comment);

            if (response.Status == GlobalVariable.ERROR)
            {
                return Results.BadRequest();
            }

            return Results.Ok(response);
        }

        public async Task<IResult> Update(UpdateCommentPresenter model, long id)
        {
            CommentSchema existingComment = await commentService.Get(id);

            if (existingComment == null)
            {
                return Results.BadRequest("Comment not found, can't update");
            }

            UpdateCommentOnPostModel comment = _mapper.Map<UpdateCommentOnPostModel>(model);
            var response = await updateCommentFlow.Excute(comment, id);

            if (response.Status == GlobalVariable.ERROR)
            {
                return Results.BadRequest();
            }

            return Results.Ok(response);
        }

        public async Task<IResult> Delete(long id)
        {
            CommentSchema existingComment = await commentService.Get(id);

            if (existingComment == null)
            {
                return Results.BadRequest("Comment not found, can't delete");
            }

            var response = await commentService.Delete(id);
            return Results.Ok(response);
        }
    }
}
