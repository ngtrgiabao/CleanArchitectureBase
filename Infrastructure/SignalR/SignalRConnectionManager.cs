using System.Collections.Concurrent;

namespace Infrastructure.SignalRHub
{
    public class SignalRConnectionManager
    {
        private static SignalRConnectionManager _instance;
        private static readonly object LockObject = new object();

        public ConcurrentDictionary<long, List<string>> Connections = new ConcurrentDictionary<long, List<string>>();

        private SignalRConnectionManager() { }

        public static SignalRConnectionManager GetInstance()
        {
            if (_instance == null)
            {
                lock (LockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new SignalRConnectionManager();
                    }
                }
            }

            return _instance;
        }

        public void AddConnection(long userId, string connectionId)
        {
            Connections.AddOrUpdate(userId, new List<string> { connectionId },
                    (key, existingValue) =>
                    {
                        if (!existingValue.Any(v => v == connectionId))
                        {
                            existingValue.Add(connectionId);
                        }

                        return existingValue;
                    });
        }

        public void RemoveConnection(int userId, string connectionId)
        {
            Connections.AddOrUpdate(userId, new List<string>(),
                    (key, existingValue) =>
                    {
                        if (existingValue.Any(v => v == connectionId))
                        {
                            existingValue.Remove(connectionId);
                        }

                        return existingValue;
                    });
        } 
    }
}
