using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
namespace WebApi.DBOperations
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }
  
    }

}