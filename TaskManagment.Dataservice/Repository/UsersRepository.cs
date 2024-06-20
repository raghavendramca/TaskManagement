using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TaskManagement.Entities.DbSet;
using TaskManagment.Dataservice.Data;
using TaskManagment.Dataservice.IRepository;
using TaskMangment.Dataservice.Repository;

namespace TaskManagment.Dataservice.Repository
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        public UsersRepository(AppDBContext appDBContext, ILogger logger) : base(appDBContext, logger)
        {

        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.Where(x => x.Status == 1).AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method has generated an error", typeof(UsersRepository));
                return new List<User>();
            }
        }
    }

}
