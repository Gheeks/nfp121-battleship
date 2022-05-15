using Battleship.Webapi.Model;
using Microsoft.AspNetCore.Mvc;
using Battleship.Logic.Services;

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
    }
}
