using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagment.Dataservice.Data;
using TaskManagment.Dataservice.IRepository;

namespace TaskMangment.Dataservice.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected AppDBContext _appDBContext;
        internal DbSet<T> dbSet;
        protected ILogger _logger;
        public GenericRepository(AppDBContext appDBContext, ILogger logger)
        {
            _appDBContext = appDBContext;
            dbSet = appDBContext.Set<T>();
            _logger = logger;

        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            var allEntities = await dbSet.ToListAsync();
            return allEntities;
        }

        public Task<bool> Delete(Guid id, string userId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}