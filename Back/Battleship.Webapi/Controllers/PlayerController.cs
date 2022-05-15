using Microsoft.AspNetCore.Mvc;
using Battleship.Webapi.Model;
using Battleship.Logic.Services;
using Battleship.Logic.Models;
using System.Linq;
using System.Security.Cryptography;

namespace Battleship.Webapi.Controllers
{
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private PlayerDbContext _context;
        private PlayerService _playerService;

        public PlayerController(PlayerDbContext context)
        {
            _context = context;
            _playerService = new PlayerService();
        }

        [HttpGet]
        public List<Player> All()
        {
            return _context.Players.ToList();
        }

        [HttpGet("{id}")]
        public Player Get(int id)
        {
            return _context.Players.First(p => p.Id == id);
        }

        [HttpPost]
        public Player Post([FromBody] Player us)
        {
            // For test only
            _context.Players.Add(us);
            _context.SaveChanges();
            return us;
        }

        [HttpPost("Login")]
        public Player Login([FromBody] Player player)
        {
            string password;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = _playerService.GetHash(sha256Hash, player.Password);
            }
            return _context.Players.First(p => p.Name == player.Name && p.Password == password);
        }

        [HttpPost("CreateNewUser")]
        public Player CreateNewUser([FromBody] Player us)
        {
            Player player = _playerService.CreateNewUser(us);
            if (player != null)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                return player;
            }
            else
            {
                throw new Exception("Cannot create player");
            }
        }
    }
}
