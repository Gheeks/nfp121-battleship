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
        public List<Stats> All([FromBody] Player player, int startNumber)
        {
            if (player.IsAdmin)
                return _context.Stats.Skip(startNumber).Take(10).ToList();
            else throw new UnauthorizedAccessException();
        }

        [HttpGet("StatsPlayer/{startNumber:int}")]
        public List<Stats> Get([FromBody] Player player, int startNumber)
        {
            return _context.Stats.Where(s => s.Player1.Id == player.Id).Skip(startNumber).Take(10).ToList();
        }
    }
}
