using System;
using System.IO;
using Battleship.Logic.Interfaces;
using Battleship.Logic.Services;
using Battleship.Logic.Static;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Logic.Tests.Interfaces
{
    [TestClass]
    public class BattleshipProgramTester
    {
        private BattleshipProgram _program;
        private Mock<ICommunicator> _commMock;
        private Communicator _communicator;
        private Mock<IPlayerPicker> _playerMock;
        private Mock<IGameCore> _gameCore;

        public BattleshipProgramTester()
        {
            _commMock = new Mock<ICommunicator>();
        }

        [TestMethod]
        public void Runs_ThenCommunicatorIsCalled()
        {
            _communicator = new Communicator();
            _program = new BattleshipProgram(_communicator, new PlayerService());
            _program.Run();
            _commMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
        }
        [TestMethod]
        public void Runs_ThenCommunicatorIsCalledWithWelcomeMessage()
        {
            _program = new BattleshipProgram(new Communicator(), new PlayerService());
            _program.Run();
            _commMock.Verify(x => x.Write(StaticStrings.WelcomeMessage), Times.Once);
        }
        [TestMethod]
        public void Runs_ThenGridIsCreated()
        {
            _communicator = new Communicator();
            _program = new BattleshipProgram(new Communicator(), new PlayerService());
            _program.Run();
            _gameCore = new Mock<IGameCore>();
            _gameCore.Verify(x => x.CreateGrid());
        }
    }
}
