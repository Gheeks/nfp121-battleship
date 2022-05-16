using Battleship.Webapi.Model;
using Microsoft.AspNetCore.Mvc;
using Battleship.Logic.Services;
using Battleship.Logic.Models;

namespace Battleship.Webapi.Controllers
{
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private PlayerDbContext _context;
        private StatsService _statsService;

        public StatsController(PlayerDbContext context)
        {
            _context = context;
            _statsService = new StatsService();
        }

        [HttpGet("{startNumber:int}")]
        public List<Stats> All(int startNumber)
        {
            return _context.Stats.Skip(startNumber).Take(10).ToList();
        }

        [HttpGet("StatsPlayer/{startNumber:int}")]
        public List<Stats> Get([FromBody] Player player, int startNumber)
        {
            return _context.Stats.Where(s => s.Player1Id == player.Id).Skip(startNumber).Take(10).ToList();
        }
    }
}
