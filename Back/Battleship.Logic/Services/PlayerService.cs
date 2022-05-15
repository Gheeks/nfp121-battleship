using System;
using System.Collections.Generic;
using Battleship.Logic.Interfaces;
using Battleship.Logic.Models;
using Battleship.Logic.Static;
using Battleship.Webapi.Controllers;
using Battleship.Webapi.Model;

namespace Battleship.Logic.Services
{
    public class PlayerService: IPlayerPicker {

        public PlayerService() {
        }

        public List<Player> ChoosePlayer()
        {
            List<Player> p = new List<Player>();
            for (int i = 0; i < 2; i++)
                p.Add(CreatePlayer());
            return p;
        }

        public Player CreatePlayer() 
        {
            return new Player("a");
        }

        public Player RandomFirstPlayer(List<Player> players)
        {
            Random random = new Random();
            int index = random.Next(players.Count);
            return players[index];
        }

        public void LoginPlayer()
        {
            //jsp quoi faire
        }
    }
}