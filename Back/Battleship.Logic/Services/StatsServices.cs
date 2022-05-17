using Battleship.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Services
{
    public class StatsService
    {
        public StatsService(){ }

        public Stats CreateNewStats(Player player1id, Grid grid1id, Player player2id, Grid grid2id, int difficulty, int player1shots, int player2shots, DateTime beginDate)
        {
            Stats s = new Stats(player1id, grid1id, player2id, grid2id, difficulty, player1shots, player2shots, DateTime.Now);
            s.PlayerTurn = GameService._instance.PlayerService.RandomFirstPlayer(new List<Player> { player1id, player2id });
            return s;
        }
    }
}
