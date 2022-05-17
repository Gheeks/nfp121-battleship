using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Logic.Models
{
    public class Stats
    {
        public int Id { get; set; }
        public Player Player1 { get; set; }
        public Grid Grid1 { get; set; }
        public Player? Player2 { get; set; }
        public Grid? Grid2 { get; set; }
        public Player? PlayerTurn { get; set; }
        public Player? PlayerVictory { get; set; }
        public int Difficulty { get; set; }
        public int Player1shots { get; set; }
        public int Player2shots { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Stats() { }
        public Stats(int difficulty, int player1shots, int player2shots, DateTime beginDate, DateTime endDate)
        {
            Difficulty = difficulty;
            Player1shots = player1shots;
            Player2shots = player2shots;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        public Stats(Player player1id, Grid grid1id, Player player2id, Grid grid2id, int difficulty, int player1shots, int player2shots, DateTime beginDate)
        {
            Player1 = player1id;
            Grid1 = grid1id;
            Player2 = player2id;
            Grid2 = grid1id;
            Difficulty = difficulty;
            Player1shots = player1shots;
            Player2shots = player2shots;
            BeginDate = beginDate;
        }
    }
}
