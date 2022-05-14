using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Battleship.Webapi.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }

    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserDbContext _uc;
        public UserController(UserDbContext uc)
        {
            _uc = uc;
        }

        [HttpGet]
        public List<User> All()
        {
            return _uc.Users.ToList();
        }

        [HttpPost]
        public User Post([FromBody] User us)
        {
            _uc.Users.Add(us);
            _uc.SaveChanges();
            return us;
        }
    }

    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> uc) : base(uc)
        {

        }
    }
}
