using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class BaseService<TEntity, TContext>
            where TEntity : class
            where TContext : DbContext
    {
        protected readonly TContext dbContext;

        public BaseService(TContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
			dbContext.Set<TEntity>().Add(entity);
			dbContext.SaveChanges();
            return entity;
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> Get(long id)
        {
            return await dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> Delete(long id)
        {
            var entity = dbContext.Set<TEntity>().Find(id);
            if (entity == null)
            {
                return entity;
            }
            dbContext.Set<TEntity>().Remove(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

		public void ClearTracker()
		{
			dbContext.ChangeTracker.Clear();
		}
	}
}
