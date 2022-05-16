using Battleship.Logic.Models;
using Microsoft.EntityFrameworkCore;

namespace Battleship.Webapi.Model
{
    public class PlayerDbContext : DbContext
    { 
        public DbSet<Player> Players { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<Grid> Grids{ get; set; }
        public DbSet<Cell> Cells { get; set; }

        public PlayerDbContext(DbContextOptions<PlayerDbContext> uc) : base(uc)
        {

        }
    }
}
