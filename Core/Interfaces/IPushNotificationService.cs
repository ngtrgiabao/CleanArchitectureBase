using Core.Models.SignalR;

namespace Core.Interfaces
{
    public interface IPushNotificationService
    {
        void SendPrivate(long userId, BaseSignalRModel model);
        void SendToGroup(string groupName, BaseSignalRModel model);
        void AddToGroup(string groupName, string connectionId);
        void RemoveFromGroup(string groupName, string connectionId);
    }
}
