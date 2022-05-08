using Battleship.Logic.Models;
using System.Collections.Generic;

namespace Battleship.Logic.Services
{
    public interface IPlayerPicker
    {
        public List<Player> ChoosePlayer();
    }
}