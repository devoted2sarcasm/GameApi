using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApi.Models;
using GameApi.Repositories;
using System.Collections.Generic;
using GameApi.Exceptions;
using GameApi.Configurations;
using Microsoft.AspNetCore.Cors;

namespace GameApi.Controllers 
{
    [ApiController]
    [EnableCors]
    public class PlayGameController : ControllerBase
    {
        private readonly GameDbContext _context;

        public PlayGameController(GameDbContext context)
        {
            _context = context;
        }

        [HttpPost("games/{Id}/play", Name = "PlayGame")]
        public GamePlayed PlayGame(int Id, [FromBody] GamePlayed gamePlayed)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidInput("Invalid request. ", ModelState);
            }
            else
            {
                BoardGame boardGame = _context.BoardGames.Find(Id);

                if (boardGame == null)
                {
                    throw new System.Exception("Game not found");
                } 
                
                GamePlayed newGamePlayed = new GamePlayed
                {
                    BoardGameId = Id,
                    Timestamp = DateTime.Now.ToString(),
                    Winner = gamePlayed.Winner,
                    Players = gamePlayed.Players,
                    Comments = gamePlayed.Comments
                };

                _context.GamesPlayed.Add(newGamePlayed);
                _context.SaveChanges();

                // return newly created object from database, including GamePlayed id
                return newGamePlayed;
            }

            
        }

        [HttpGet("games/{Id}/play", Name = "GetGamesPlayedByGameId")]
        public List<GamePlayed> GetGamesPlayedByGameId(int Id)
        {
            return this._context.GamesPlayed
                .Where(game => game.BoardGameId == Id)
                .ToList();
        }

        [HttpGet("games/wonby/{player}", Name = "GetGamesWonByPlayer")]
        public List<GamePlayed> GetGamesWonByPlayer(string player)
        {
            return this._context.GamesPlayed
                .Where(game => game.Winner == player)
                .ToList();
        }


    }
}