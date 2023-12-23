using Application.Controllers.Message.Presenter;
using Application.Helpers;
using AutoMapper;
using Core;
using Core.Interfaces;
using Core.Models;
using Core.Models.Message;
using Infrastructure.Services;
using Infrastructure.SignalRHub;
using Microsoft.AspNetCore.SignalR;
using UseCase.Message;

namespace Application.Controllers.Message
{
    public class MessageCtrl : BaseController
    {
        private readonly SendMessageFlow sendMessageFlow;
        public MessageCtrl(HttpContext httpContext, DataContext ctx, byte[] _secretKey, IMapper _mapper, IHubContext<SignalrHub, IHubClientService> hub)
            : base(httpContext, ctx, _secretKey, _mapper, hub)
        {
            sendMessageFlow = new SendMessageFlow(new MessageService(ctx), new PushNotificationService(hub));
        }

        public async Task<IResult> FetchChatMessage()
        {
            ResponseModel response = await fetchChatMessageFlow.Execute();
            return Results.Ok(response.Result);
        }
        public async Task<IResult> FetchChatList(string userName)
        {
            long userId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = await fetchChatListFlow.Execute(userName, userId);
            return Results.Ok(response.Result);
        }
        public async Task<IResult> FetchChatProfile(long userId)
        {
            ResponseModel response = await fetchChatProfileFlow.Execute(userId);
            return Results.Ok(response.Result);
        }
        public async Task<IResult> FetchChatRoom(long chatUserId, string startTime, string endTime)
        {
            long currentUserId = Common.GetCurrentUserId(httpContext);
            ResponseModel response = await fetchChatRoomFlow.Execute(currentUserId, chatUserId, startTime, endTime);
            return Results.Ok(response.Result);
        }
        public async Task<IResult> NotificationControl()
        {
            ResponseModel response = await notificationControlFlow.Execute();
            return Results.Ok(response.Result);
        }
        public async Task<IResult> ReadAllMessage()
        {
            ResponseModel response = await readAllMessageFlow.Execute();
            return Results.Ok(response.Result);
        }
        public async Task<IResult> SendMessage(SendMessagePresenter presenter)
        {
            var model = mapper.Map<SendMessageModel>(presenter);
            long userId = Common.GetCurrentUserId(httpContext);
            model.SenderId = userId;
            ResponseModel response = await sendMessageFlow.Execute(model);
            return Results.Ok(response.Result);
        }


    }
}
