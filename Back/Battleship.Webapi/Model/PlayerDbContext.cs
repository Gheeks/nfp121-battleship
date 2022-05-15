using Battleship.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace Battleship.Webapi.Model
{
    public class PlayerDbContext : DbContext
    { 
        public DbSet<Player> Players { get; set; }

        public PlayerDbContext(DbContextOptions<PlayerDbContext> uc) : base(uc)
        {

        }
    }
}
