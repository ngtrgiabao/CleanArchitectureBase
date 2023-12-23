using Application.Controllers.Feed;
using Application.Controllers.Feed.Presenter;
using AutoMapper;
using Core;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.Constant;
using Application.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class FeedRouter
    {
        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> _hub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel>();

            var routeInfos = new List<RouterModel>
            {
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-feed-friend",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchFriend()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-feed-people",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) => 
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchPeople()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-post-list",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchPostList()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-premium-photos",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                     Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                              await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchPremiumPhotos()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-pro-member",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchProMember()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-feed-story",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchStory()
                },
                new RouterModel()
                {
                    Method = "GET",
                    Module = "Feed",
                    Path = "fetch-feed-trend",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async (HttpContext httpContext, DataContext db, IMapper mapper) =>  
                              await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).FetchTrend()
                },
                new RouterModel()
                {
                    Method = "POST",
                    Module = "Feed",
                    Path = "create-post",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async ([FromBody] CreatePostPresenter model, HttpContext httpContext, DataContext db, IMapper mapper) =>
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).CreatePost(model)

                },
                new RouterModel()
                {
                    Method = "POST",
                    Module = "Feed",
                    Path = "like-post",
                    ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                    Action = async ([FromBody] LikePresenter model, HttpContext httpContext, DataContext db, IMapper mapper) =>
                             await new FeedCtrl(httpContext, db, secretKey, mapper, _hub).LikePost(model)

                }
            };

            foreach (var routeInfo in routeInfos)
            {
                routers.Add(routeInfo);
            }
            return routers;
        }
    }
}
