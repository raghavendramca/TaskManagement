

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Entities.DbSet;

namespace TaskManagment.Dataservice.Data
{

     public class AppDBContext : IdentityDbContext
     {
          public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
          {

          }

          public new DbSet<User> Users { get; set; }

     }

}