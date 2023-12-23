using Core.Models.SignalR;

namespace Core.Interfaces
{
    public interface IHubClientService
    {
        Task PushNotification(BaseSignalRModel model);
    }
}
