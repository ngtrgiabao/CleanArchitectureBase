using Core.Interfaces;
using Core.Schemas;
using Core;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.SignalRHub
{ 
    public class SignalrHub : Hub<IHubClientService>
    {
        private readonly DataContext dbContext;
        private readonly SignalRConnectionManager _connectionManager;
        public SignalrHub(DataContext dataContext)
        {
            dbContext = dataContext;
            _connectionManager = SignalRConnectionManager.GetInstance();
        }

        public override Task OnConnectedAsync()
        {
            string? userIdString = Context?.GetHttpContext().Request.Query["userId"];
            if (!string.IsNullOrWhiteSpace(userIdString))
            {
                DeviceTokenSchema dt = new DeviceTokenSchema();
                dt.UserId = long.Parse(userIdString);
                dt.ConnectionId = Context.ConnectionId;
                dbContext.DeviceTokens.Add(dt);
                dbContext.SaveChanges();
                _connectionManager.AddConnection(dt.UserId, dt.ConnectionId);
            }
            return base.OnConnectedAsync();
        }
    }
}
