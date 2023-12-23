using Core.Models;
using Application.Routers.Manager;
using Core.Interfaces;
using Microsoft.AspNetCore.SignalR;
using Infrastructure.SignalRHub;

namespace Application.Routers
{
    public class ZRouterManager
    {
        private readonly byte[] secretKey;
        private readonly IHubContext<SignalrHub, IHubClientService> chatHub;
        public ZRouterManager(IHubContext<SignalrHub, IHubClientService> _hub, byte[] _secretKey)
        {
            secretKey = _secretKey;
            chatHub = _hub;
        }
        public List<RouterModel> Get()
        {
            List<RouterModel> routers = new List<RouterModel>();

            var routersToAdd = new List<IEnumerable<RouterModel>>
            {
                new LikeTypeManagerRouter().Get(),
                new PublicRouter         ().Get(chatHub, secretKey),
                new FeedRouter           ().Get(chatHub, secretKey),
                new GroupRouter          ().Get(chatHub, secretKey),
                new MessageRouter        ().Get(chatHub, secretKey),
                new UserManagerRouter    ().Get(),
                new PostManagerRouter    ().Get(),
                new GroupManagerRouter   ().Get(chatHub, secretKey),
                new PermRouter           ().Get(),
                new RoleManagerRouter    ().Get(),
                new CommentRouter        ().Get(chatHub, secretKey),
                new CommentManagerRouter ().Get(),
            };

            foreach (var routerList in routersToAdd)
            {
                routers = routers.Union(routerList).ToList();
            }

            return routers;
        }

    }
}
