namespace Core.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Get(long id);
        Task<T> Delete(long id);
		void ClearTracker();

	}

}
