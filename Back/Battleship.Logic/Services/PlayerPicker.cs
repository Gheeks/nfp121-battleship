using System;
using System.Collections.Generic;
using Battleship.Logic.Interfaces;
using Battleship.Logic.Models;
using Battleship.Logic.Static;

namespace Battleship.Logic.Services
{
    public class PlayerPicker: IPlayerPicker {
        private ICommunicator _communicator;

        public PlayerPicker() {
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
            _communicator.Write(StaticStrings.ChosePlayerMessage);
            return new Player(_communicator.Read());
        }

    }
}