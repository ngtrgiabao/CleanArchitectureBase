using Core.Constant;
using Core.Models;
using Core.Schemas;
using Core.Models.Message;
using Core.Models.SignalR;
using Core.Interfaces;

namespace UseCase.Message
{
    public class SendMessageFlow
    {
        private readonly IPushNotificationService pushNotificationService;
        private readonly IMessageService messageService;
        public SendMessageFlow(IMessageService _messageService, IPushNotificationService _pushNotificationService)
        {
            pushNotificationService = _pushNotificationService;
            messageService = _messageService;
        }

        public async Task<ResponseModel> Execute(SendMessageModel model)
        {
            MessageSchema ms = new MessageSchema();
            ms.CreatedAt = DateTime.UtcNow;
            ms.SenderId = model.SenderId;
            ms.ReceiverId = model.SendToId;
            await messageService.Add(ms);

            MessageModel msg = new MessageModel();
            msg.Content = model.Content;
            msg.Timestamp = DateTime.UtcNow.ToString();
            pushNotificationService.SendPrivate(model.SendToId, msg);
            return new ResponseModel(GlobalVariable.SUCCESS, ms);
        }
    }

}
