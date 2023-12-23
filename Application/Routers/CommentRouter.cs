using Core.Models;
using Core;
using Application.Controllers.Comment;
using AutoMapper;
using Application.Controllers.Comment.Presenter;
using Microsoft.AspNetCore.Mvc; 
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Routers
{ 
    public class CommentRouter
    {
        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> _hub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel>();
            var commentRouter = new RouterModel()
            {
                Method = "POST",
                Module = "Comment",
                Path = "comment-on-post",
                ProfileType = "[]",
                Action = async (HttpContext httpContext, DataContext db, IMapper mapper, [FromBody] CommentOnPostPresenter presenter) =>
                         await new CommentCtrl(httpContext, db, secretKey, mapper, _hub).CommentOnPost(presenter)
            };
            routers.Add(commentRouter);
            return routers;
        }
    }
}
