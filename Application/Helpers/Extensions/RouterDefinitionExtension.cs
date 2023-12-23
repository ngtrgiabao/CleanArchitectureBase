using Application.Routers;
using Core.Interfaces;
using Core.Models;
using Infrastructure.SignalRHub;
using Microsoft.AspNetCore.SignalR;
using System.Text;

namespace Application.Helpers.Extensions
{
    public static class RouterDefinitionExtension
    {
        public static WebApplication RouterDefinition(this WebApplication app)
        {
            string prefix = "api/";
            var configuration = app.Services.GetRequiredService<IConfiguration>();
            string? secretKey = configuration["Configuration:SecretKey"];
            byte[] key = Encoding.ASCII.GetBytes(secretKey);
            var hub = app.Services.GetRequiredService<IHubContext<SignalrHub, IHubClientService>>();
            List<RouterModel> routers = new ZRouterManager(hub, key).Get();
            foreach (RouterModel router in routers)
            {
                switch (router.Method)
                {
                    case "GET":
                        app.MapGet(prefix + router.Path, router.Action);
                        break;
                    case "POST":
                        app.MapPost(prefix + router.Path, router.Action);
                        break;
                    case "PUT":
                        app.MapPut(prefix + router.Path, router.Action);
                        break;
                    case "DELETE":
                        app.MapDelete(prefix + router.Path, router.Action);
                        break;
                }
            } 
            return app;
        }
    }
}
