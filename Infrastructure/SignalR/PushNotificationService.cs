using Core.Interfaces;
using Core.Models.SignalR;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalRHub
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly IHubContext<SignalrHub, IHubClientService> hubContext;
        private readonly SignalRConnectionManager _connectionManager;
        public PushNotificationService(IHubContext<SignalrHub, IHubClientService> _hubContext)
        {
            hubContext = _hubContext;
            _connectionManager = SignalRConnectionManager.GetInstance();
        }

        public async void SendToGroup(string groupName, BaseSignalRModel model)
        {
            await hubContext.Clients.Group(groupName).PushNotification(model);
        }

        public async void AddToGroup(string groupName, string connectionId)
        {
            await hubContext.Groups.AddToGroupAsync(connectionId, groupName);
        }

        public async void RemoveFromGroup(string groupName, string connectionId)
        {
            await hubContext.Groups.RemoveFromGroupAsync(connectionId, groupName);
        }

        public async void SendPrivate(long userId, BaseSignalRModel model)
        {
            var connectionIds = new List<string>();
            var canGetValue = _connectionManager.Connections.TryGetValue(userId, out connectionIds);

            if (canGetValue && connectionIds != null && connectionIds.Count != 0)
            {
                await hubContext.Clients.Clients(connectionIds).PushNotification(model);
            }
        }
    }
}
