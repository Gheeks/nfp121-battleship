using System;

namespace Battleship.Logic.Models
{
    public class Player
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }

        public Player(string name, string mail, string password)
        {
            Name = name;
            Mail = mail;
            Password = password;
        }
    }
}