using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            return new Player("1","a@a.fr", "Teest567!");
        }

        public Player RandomFirstPlayer(List<Player> players)
        {
            Random random = new Random();
            int index = random.Next(players.Count);
            return players[index];
        }

        public void LoginPlayer(string name, string password)
        {
            
        }

        public Player CreateNewUser(Player player)
        {
            if (IsPasswordCorrect(player.Password))
            {
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    player.Password = GetHash(sha256Hash, player.Password);
                }

                if (IsEmailIsReal(player.Mail))
                {
                    return new Player(player.Name, player.Mail, player.Password);
                }
            }
            return null;
        }

        public bool IsPasswordCorrect(string password) 
        {
            if (password.Length > 7 && password.Any(char.IsUpper) && password.Any(char.IsNumber) && password.Any(ch => !char.IsLetterOrDigit(ch)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsEmailIsReal(string mail) 
        {
            var trimmedEmail = mail.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            var sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}