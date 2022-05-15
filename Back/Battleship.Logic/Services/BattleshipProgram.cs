using System;
using Battleship.Logic.Interfaces;
using Battleship.Logic.Models;
using Battleship.Logic.Static;

namespace Battleship.Logic.Services
{
    public class BattleshipProgram : IBattleshipProgram
    {
        private ICommunicator _communicator;
        private IPlayerPicker _playerPicker;
        public BattleshipProgram(ICommunicator communicator, IPlayerPicker playerPicker)
        {
            _communicator = communicator;
            _playerPicker = playerPicker;
        }

        public void Run()
        {
            _communicator.Write(StaticStrings.WelcomeMessage);
            _communicator.Write(StaticStrings.ChoseFirstPlayerMessage);
            var players = _playerPicker.ChoosePlayer();
        }
    }
}