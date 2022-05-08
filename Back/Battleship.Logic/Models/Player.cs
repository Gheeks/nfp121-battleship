using System;

namespace Battleship.Logic.Models
{
    public class Player
    {        
        public Guid PlayerId = Guid.Empty;
        public string Name;

        public Player(string name)
        {
            PlayerId = new Guid();
            Name = name;
        }
    }
}