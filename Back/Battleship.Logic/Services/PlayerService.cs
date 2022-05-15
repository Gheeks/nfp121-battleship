using System;
using System.Collections.Generic;
using Battleship.Logic.Models;

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
            return new Player("1","a@a.fr","a");
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

        public Player CreateNewUser(Player player)
        {
            // Todo : Check Password
            if (IsPasswordCorrect(player.Password))
            {
                // If email contains @ and .
                if (IsEmailIsReal(player.Mail))
                {
                    return new Player(player.Name, player.Mail, player.Password);
                }
            }
            return null;
        }

        public bool IsPasswordCorrect(string password) { return false; }

        public bool IsEmailIsReal(string mail) { return false; }

    }
}