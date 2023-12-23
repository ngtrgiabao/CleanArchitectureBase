using Application.Controllers.Feed.Presenter;
using Application.Controllers.Manager.Post;
using Application.Controllers.Manager.Post.Presenter;
using AutoMapper;
using Core;
using Core.Constant;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Application.Routers
{
    public class PostManagerRouter
    {
        public IEnumerable<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>()
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Posts",
                    Path = "posts",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (DataContext db, IMapper mapper) => await new PostManagerCtrl(mapper, db).Get()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Posts",
                    Path = "posts/id",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (DataContext db, IMapper mapper, long id) => await new PostManagerCtrl(mapper, db).GetPostById(id)
                },
                new RouterModel()
                {
                    Method = "POST",
                    Module = "Posts",
                    Path = "posts",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async ([FromBody] CreatePostPresenter model, DataContext db, IMapper mapper) => await new PostManagerCtrl(mapper, db).Create(model)
                },
                new RouterModel()
                {
                    Method = "PUT",
                    Module = "Posts",
                    Path = "posts",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async ([FromBody] UpdatePostPresenter model, DataContext db, IMapper mapper, long id) => await new PostManagerCtrl(mapper, db).Update(model, id)
                },
                new RouterModel()
                {
                    Method = "DELETE",
                    Module = "Posts",
                    Path = "posts",
                    ProfileType = "[" + PermUtil.ADMIN_PROFILE + "]",
                    Action = async (long id, DataContext db, IMapper mapper) => await new PostManagerCtrl(mapper, db).Delete(id)
                }
            };
            return routers;
        }
    }
}
