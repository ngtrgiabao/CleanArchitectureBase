using Core;
using AutoMapper;
using Application.Controllers.Comment.Presenter;
using Core.Models.Comment;
using Application.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Controllers.Comment
{
    public class CommentCtrl : BaseController
    {
        public CommentCtrl(HttpContext _httpContext, DataContext dbContext, byte[] _secretKey, IMapper _mapper, IHubContext<SignalrHub, IHubClientService> hub)
                : base(_httpContext, dbContext, _secretKey, _mapper, hub) { }

        public async Task<IResult> CommentOnPost(CommentOnPostPresenter presenter)
        {
            var model = mapper.Map<CommentOnPostModel>(presenter);
            model.CommenterId = Common.GetCurrentUserId(httpContext);
            var response = await commentOnPostFlow.Execute(model);
            return Results.Ok(response.Result);
        }
    }
}
