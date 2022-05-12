using Battleship.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Logic.Services
{
    public class GameService
    {
        public GridService GridService { get; set; }
        public PlayerService PlayerService { get; set; }
        public List<Player> Players { get; set; }

        public GameService CreateNewGame()
        {
            return null;
        }
    }
}
