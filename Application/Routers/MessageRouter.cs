using AutoMapper;
using Core;
using Core.Models;
using Core.Constant;
using Application.Controllers.Message.Presenter;
using Application.Controllers.Message;
using Microsoft.AspNetCore.Mvc;
using Application.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class MessageRouter
    {

        public IEnumerable<RouterModel> Get(IHubContext<SignalrHub, IHubClientService> chatHub, byte[] secretKey)
        {
            List<RouterModel> routers = new List<RouterModel>();
            var routeInfos = new List<RouterModel>
            {
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "fetch-chat-list",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper, string name) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper,chatHub).FetchChatList(name)
                },
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "read-all-message",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper, long userId) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper,chatHub).ReadAllMessage()
                },
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "notification-control",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper, long userId) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper,chatHub).NotificationControl()
                },
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "fetch-chat-room",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext,DataContext db, IMapper mapper, long userId, string startTime, string endTime) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper, chatHub).FetchChatRoom(userId, startTime, endTime)
                },
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "fetch-chat-profile",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper, long userId) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper, chatHub).FetchChatProfile(userId)
                },
                new RouterModel()
                {
                        Method      = "GET",
                        Module      = "Message",
                        Path        = "fetch-chat-message",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper, long userId) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper, chatHub).FetchChatMessage()
                },
                new RouterModel()
                {
                        Method      = "POST",
                        Module      = "Message",
                        Path        = "send-message",
                        ProfileType = Common.SetPermission(PermUtil.ADMIN_PROFILE, PermUtil.STAFF_PROFILE, PermUtil.END_USER),
                        Action      = async (HttpContext httpContext, DataContext db, IMapper mapper,[FromBody] SendMessagePresenter presenter) =>
                                      await new MessageCtrl(httpContext, db, secretKey, mapper, chatHub).SendMessage(presenter)
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
