using AutoMapper;
using Core;
using Core.Interfaces;
using Infrastructure.Services;
using Infrastructure.SignalRHub;
using Microsoft.AspNetCore.SignalR;
using UseCase.Comment;
using UseCase.Feed;
using UseCase.Group;
using UseCase.Message;

namespace Application.Controllers
{
    public class BaseController
    {
        #region common
        protected readonly DataContext context;
        protected readonly byte[] secretKey;
        protected readonly IMapper mapper;
        protected readonly HttpContext httpContext;
        protected readonly IHubContext<SignalrHub, IHubClientService> hub;
        #endregion

        #region Feed
        protected readonly FeedPostListFlow feedPostListFlow;
        protected readonly FetchFriendFlow fetchFriendFlow;
        protected readonly FetchPeopleFlow fetchPeopleFlow;
        protected readonly FetchPremiumPhotosFlow fetchPremiumPhotosFlow;
        protected readonly FetchProMemberFlow fetchProMemberFlow;
        protected readonly FetchStoryFlow fetchStoryFlow;
        protected readonly FetchTrendFlow fetchTrendFlow;
        protected readonly CreatePostFlow createPostFlow;
        protected readonly LikePostFlow likePostFlow;
        #endregion

        #region Message
        protected readonly SendMessageFlow sendMessageFlow;
        protected readonly FetchChatMessageFlow fetchChatMessageFlow;
        protected readonly ReadAllMessageFlow readAllMessageFlow;
        #endregion

        #region Comment
        protected readonly CommentOnPostFlow commentOnPostFlow;
        #endregion

        protected readonly FetchCategoryFlow fetchCategoryFlow;
        protected readonly FetchGroupSuggestFlow fetchGroupSuggestFlow;
        protected readonly FetchTagGroupFlow fetchTagGroupFlow;
        protected readonly FetchChatListFlow fetchChatListFlow;
        protected readonly FetchChatProfileFlow fetchChatProfileFlow;
        protected readonly FetchChatRoomFlow fetchChatRoomFlow;
        protected readonly NotificationControlFlow notificationControlFlow;
        protected readonly CreateGroupFlow createGroupFlow;
        protected readonly UpdateGroupFlow updateGroupFlow;

        public BaseController(HttpContext _httpContext, DataContext ctx, byte[] _secretKey, IMapper _mapper, IHubContext<SignalrHub, IHubClientService> _hub)
        {
            #region common
            secretKey = _secretKey;
            mapper = _mapper;
            context = ctx;
            httpContext = _httpContext;
            hub = _hub;
            #endregion

            #region services
            IMessageService messageService = new MessageService(ctx);
            IPushNotificationService pushNotificationService = new PushNotificationService(_hub);
            #endregion
         
            #region Feed
            feedPostListFlow = new FeedPostListFlow(ctx);
            fetchFriendFlow = new FetchFriendFlow(ctx);
            fetchPeopleFlow = new FetchPeopleFlow(ctx);
            fetchPremiumPhotosFlow = new FetchPremiumPhotosFlow(ctx);
            fetchProMemberFlow = new FetchProMemberFlow(ctx);
            fetchStoryFlow = new FetchStoryFlow(ctx);
            fetchTrendFlow = new FetchTrendFlow(ctx);
            fetchCategoryFlow = new FetchCategoryFlow(ctx);
            fetchGroupSuggestFlow = new FetchGroupSuggestFlow(ctx);
            fetchTagGroupFlow = new FetchTagGroupFlow(ctx);
            fetchChatListFlow = new FetchChatListFlow(ctx);
            fetchChatProfileFlow = new FetchChatProfileFlow(ctx);
            fetchChatRoomFlow = new FetchChatRoomFlow(ctx);
            notificationControlFlow = new NotificationControlFlow(ctx);
            createPostFlow = new CreatePostFlow(ctx);
            likePostFlow = new LikePostFlow(ctx);
            createGroupFlow = new CreateGroupFlow(ctx);
            updateGroupFlow = new UpdateGroupFlow(ctx);
            #endregion

            #region Comment
            commentOnPostFlow = new CommentOnPostFlow(ctx);
            #endregion

            #region Message
            sendMessageFlow = new SendMessageFlow(messageService, pushNotificationService);
            fetchChatMessageFlow = new FetchChatMessageFlow(ctx);
            readAllMessageFlow = new ReadAllMessageFlow(ctx);
            #endregion
        }

    }
}
