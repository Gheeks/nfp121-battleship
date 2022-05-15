using Microsoft.AspNetCore.Mvc;
using Battleship.Webapi.Model;

namespace Battleship.Webapi.Controllers
{
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

        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _uc.Users.Find(id);
        }


        [HttpPost]
        public User Post([FromBody] User us)
        {
            _uc.Users.Add(us);
            _uc.SaveChanges();
            return us;
        }
    }
}
