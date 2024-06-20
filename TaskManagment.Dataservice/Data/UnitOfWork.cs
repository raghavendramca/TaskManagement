using Microsoft.Extensions.Logging;
using TaskManagment.Dataservice.IConfiguration;
using TaskManagment.Dataservice.IRepository;
using TaskManagment.Dataservice.Repository;

namespace TaskManagment.Dataservice.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDBContext _context;
        private readonly ILogger _logger;

        public UnitOfWork(AppDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("db_logs");

            Users = new UsersRepository(_context,_logger);

        }
        public IUsersRepository Users { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}