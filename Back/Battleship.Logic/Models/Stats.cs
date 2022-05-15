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
        public int Player1Id { get; set; }
        public int Player2Id { get; set; }
        public int Difficulty { get; set; }
        public int Player1shots { get; set; }
        public int Player2shots { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public Stats(int player1Id, int player2Id, int difficulty, int player1Shots, int player2Shots, DateTime beginDate, DateTime endDate)
        {
            Player1Id = player1Id;
            Player2Id = player2Id;
            Difficulty = difficulty;
            Player1shots = player1Shots;
            Player2shots = player2Shots;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        private Stats(int player1Id, int player2Id, int difficulty, DateTime beginDate, DateTime endDate)
        {
            Player1Id = player1Id;
            Player2Id = player2Id;
            Difficulty = difficulty;
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
