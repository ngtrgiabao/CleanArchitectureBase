using Application.Controllers.Comment.Presenter;
using Application.Controllers.Manager.Comment;
using Application.Controllers.Manager.Comment.Presenter;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Routers.Manager
{
    public class CommentManagerRouter
    {
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>()
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Comments",
                    Path = "comments",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (DataContext db, IMapper mapper) => await new CommentManagerCtrl(mapper, db).Get()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Comments",
                    Path = "comments/id",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (long id, DataContext db, IMapper mapper) => await new CommentManagerCtrl(mapper, db).GetCommentById(id)
                },
                new RouterModel()
                {
                    Method = "POST",
                    Module = "Comments",
                    Path = "comments",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async ([FromBody] CommentOnPostPresenter model, DataContext db, IMapper mapper) => await new CommentManagerCtrl(mapper, db).Create(model)
                },
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "Comments",
                    Path = "comments",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async ([FromBody] UpdateCommentPresenter model, DataContext db, IMapper mapper, long id) => await new CommentManagerCtrl(mapper, db).Update(model, id)
                },
                new RouterModel()
                {
                    Method = "DELETE",
                    Module = "Comments",
                    Path = "comments",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (long id, DataContext db, IMapper mapper) => await new CommentManagerCtrl(mapper, db).Delete(id)
                }
            };
            return routers;
        }
    }
}
