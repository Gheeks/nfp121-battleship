using Microsoft.AspNetCore.Mvc;
using Battleship.Webapi.Model;
using Battleship.Logic.Services;
using Battleship.Logic.Models;
using System.Security.Cryptography;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        [HttpGet, Authorize]
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
        public IActionResult Login([FromBody] Player player)
        {
            string password;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                password = _playerService.GetHash(sha256Hash, player.Password);
            }
            var p = _context.Players.Where(pl => pl.Name == player.Name && pl.Password == password).FirstOrDefault();
            if (p != null)
            {
                string token = CreateToken(p);
                return Ok(new AuthenticatedResponse { Token = token });
            };
            return Unauthorized();
        }

        [HttpPost("CreateNewUser")]
        public IActionResult CreateNewUser([FromBody] Player us)
        {
            Player player = _playerService.CreateNewUser(us);
            if (player != null)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                string token = CreateToken(player);
                return Ok(new AuthenticatedResponse { Token = token });
            }
            else
            {
                throw new Exception("Cannot create player");
            }
        }

        public string CreateToken(Player p)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qjhYyK^fPdcodL8@DG1#xaj2yI%%NYBGScBp7QMH30diTzN00yQbQQn3$9iBP6G^QC3E@DGcwbGXd29Ey!VhvARf0Ex3BV"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:5001",
                audience: "https://localhost:5001",
                claims: new List<Claim>{
                            new Claim(JwtRegisteredClaimNames.Sub, p.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Name, p.Name),
                },
                expires: DateTime.Now.AddDays(7),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }

    }
}
