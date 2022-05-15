using System;
using Battleship.Logic.Interfaces;

namespace Battleship.Logic.Services
{
    public class Communicator : ICommunicator
    {
        public string Read()
        {
            return Console.ReadLine();
        }

        public void Write(string str)
        {
            Console.WriteLine(str);
        }
    }
}