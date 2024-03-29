﻿using Battleship.Logic.Models;
using Battleship.Logic.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.Logic.Services
{
    public class GameService
    {
        public static GameService _instance { get; private set; } = new GameService();
        public GridService GridService { get; set; }
        public PlayerService PlayerService { get; set; }
        public List<Player> Players { get; set; }
        public Dictionary<Player, Grid> GridsPlayer { get; set; }

        public Player PlayerToPlay { get; set; }

        public GameService()
        {
            CreateNewGame();
        }

        public GameService CreateNewGame()
        {
            GridService = new GridService();
            PlayerService = new PlayerService();
            Players = new List<Player>();
            GridsPlayer = new Dictionary<Player, Grid>();
            return this;
        }

        public void CreateGridToPLayers(List<Player> players, int dim)
        {
            foreach (Player p in players)
            {
                if (dim > 0)
                {
                    GridsPlayer.Add(p, GridService.CreateNewGrid(dim));
                }
                else throw new Exception("No dimension provided to create grid");
            }
        }

        public Grid GetPlayerGrid(Player p)
        {
            try
            {
                return GridsPlayer.First(gp => gp.Key == p).Value;
            }
            catch (Exception ex)
            {
                throw new Exception(ErrorEnum.SHIP_PLACED_ON_OTHER.ToString());
            }
        }

        public bool PlaceShipsForPlayer(Player p, Grid grid)
        {
            Grid g = GetPlayerGrid(p);
            return GridService.PlaceShipFromFrontGrid(g, grid);
        }

        public bool TryHitBoatWithPlayer(Player playerTarget, int x, int y)
        {
            Grid g = GetPlayerGrid(playerTarget);
            GridStatus gridStatus = g.GetState(x, y);
            if (gridStatus == GridStatus.NoShip_NotTouched || gridStatus == GridStatus.Ship_NotTouched)
            {
                GridService.SwitchState(g, x, y);
                PlayerToPlay = playerTarget;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool TryHitBoatWithGrid(Grid g, int x, int y)
        {
            GridStatus gridStatus = g.GetState(x, y);
            if (gridStatus == GridStatus.NoShip_NotTouched || gridStatus == GridStatus.Ship_NotTouched)
            {
                GridService.SwitchState(g, x, y);
                PlayerToPlay = g.PlayerOwner;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
