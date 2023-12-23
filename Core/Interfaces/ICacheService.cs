namespace Core.Interfaces
{
    public interface ICacheService<T> where T : class
    {
        void SetItems(string cacheKey, List<T> datas);
        void SetItem(string cacheKey, T data);
        List<T> GetItems(string cacheKey);
        T GetItem(string cacheKey);
    }
}
