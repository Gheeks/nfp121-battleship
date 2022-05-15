using Microsoft.EntityFrameworkCore;

namespace Battleship.Webapi.Model
{
    public class UserDbContext : DbContext
    { 
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> uc) : base(uc)
        {

        }
    }
}
