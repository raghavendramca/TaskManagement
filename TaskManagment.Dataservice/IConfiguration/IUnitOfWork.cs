using TaskManagment.Dataservice.IRepository;

namespace TaskManagment.Dataservice.IConfiguration
{
    public interface IUnitOfWork{
        IUsersRepository Users {get;}

        Task CompleteAsync ();
    }
}