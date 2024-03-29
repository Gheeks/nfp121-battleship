﻿using Microsoft.AspNetCore.Mvc;
using Battleship.Webapi.Model;
using Battleship.Logic.Services;
using Battleship.Logic.Models;
using System.Security.Cryptography;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Battleship.Logic.Models.Enums;

namespace Battleship.Webapi.Controllers
{
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        private PlayerDbContext _context;
        private GridService _gridService;
        private StatsService _statsService;
        private AIService _aiService;

        public GridController(PlayerDbContext context)
        {
            _context = context;
            _gridService = new GridService();
            _aiService = new AIService();
            _statsService = new StatsService();
        }

        [HttpPost("CreateNewIAGame/{difficulty:int}")]
        public Grid Post([FromBody] Grid grid, [FromRoute] int difficulty)
        {
            Player p = grid.PlayerOwner;
            Grid gridInit = new Grid
            {
                PlayerOwner = grid.PlayerOwner,
                Dimensions = grid.Dimensions,
            };

            Grid aiGridInit = new Grid
            {
                Dimensions = grid.Dimensions,
            };
            _context.SaveChanges();

            Grid aiGrid = new Grid();
            aiGrid = _gridService.CreateNewGrid(aiGrid.Dimensions);
            _aiService.AutoShipPlacement(aiGrid);

            Grid g = _gridService.CreateNewGrid(grid.Dimensions);
            if (GameService._instance.GridService.PlaceShipFromFrontGrid(g, grid))
            {
                foreach (List<Cell> cells in g.cells)
                {
                    foreach (Cell cell in cells)
                    {
                        cell.GridId = gridInit.Id;
                        _context.Cells.Add(cell);
                    }
                }

                foreach (List<Cell> cells in aiGrid.cells)
                {
                    foreach (Cell cell in cells)
                    {
                        cell.GridId = aiGrid.Id;
                        _context.Cells.Add(cell);
                    }
                }

                Stats s = _statsService.CreateNewStats(grid.PlayerOwner, gridInit, null, aiGridInit, difficulty, 0, 0, DateTime.Now);
                _context.Stats.Add(s);

                _context.SaveChanges();
                return g;
            }
            else
            {
                throw new Exception("Cannot create a game for now!");
            }
            return null;
        }

        [HttpPost("TryHitGrid/{x:int}/{y:int}")]
        public Grid TryHitGrid([FromBody] Grid grid, [FromRoute] int x, [FromRoute] int y)
        {
            Cell tryToHit = _context.Cells.Where(c => c.GridId == grid.Id && c.x == x && c.y == y).First();
            if (tryToHit.touched == GridStatus.Ship_Touched || tryToHit.touched == GridStatus.NoShip_Touched)
            {
                throw new Exception("Already played");
            }
            else
            {
                if (GameService._instance.TryHitBoatWithGrid(grid, x, y))
                {
                    return grid;
                }
                else
                {
                    // If fail -> IA plays
                    return _aiService.HitPlayerGrid(grid, _context.Stats.Where(s => s.Grid1 == grid || s.Grid2 == grid).First().Difficulty);
                }
            }
        }

    }
}
