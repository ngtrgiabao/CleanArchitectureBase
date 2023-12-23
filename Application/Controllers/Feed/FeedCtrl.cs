using AutoMapper;
using Core.Models;
using Core;
using Application.Controllers.Feed.Presenter;
using Core.Models.Feed;
using Application.Helpers;
using Microsoft.AspNetCore.SignalR; 
using Core.Interfaces;
using Infrastructure.SignalRHub;

namespace Application.Controllers.Feed
{
    public class FeedCtrl : BaseController
    {
        public FeedCtrl(HttpContext _httpContext, DataContext ctx, byte[] _secretKey, IMapper mapper, IHubContext<SignalrHub, IHubClientService> _hub)
            : base(_httpContext, ctx, _secretKey, mapper, _hub) { }

        public async Task<IResult> FetchFriend()
        {
            long userId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = await fetchFriendFlow.Execute(userId);
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchPeople()
        {
            ResponseModel response = await fetchPeopleFlow.Execute();
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchPostList()
        {
            long userId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = await feedPostListFlow.Execute(userId);
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchPremiumPhotos()
        {
            long userId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = fetchPremiumPhotosFlow.Execute();
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchProMember()
        {
            ResponseModel response = fetchProMemberFlow.Execute();
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchTrend()
        {
            ResponseModel response = fetchTrendFlow.Execute();
            return Results.Ok(response.Result);
        }

        public async Task<IResult> FetchStory()
        {
            long userId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = fetchStoryFlow.Execute(userId);
            return Results.Ok(response.Result);
        }

        public async Task<IResult> CreatePost(CreatePostPresenter model)
        {
            long userId = Common.GetCurrentUserId(httpContext);
            PostModel post = mapper.Map<PostModel>(model);
            post.UserId = userId;
            ResponseModel response = await createPostFlow.Execute(post);
            return Results.Ok(response.Result);
        }

        public async Task<IResult> LikePost(LikePresenter presenter)
        {
            long userId = Common.GetCurrentUserId(httpContext);
            LikeModel model = mapper.Map<LikeModel>(presenter);
            model.LikerId = userId;
            ResponseModel response = await likePostFlow.Execute(model);
            return Results.Ok(response.Result);
        }
    }
}
