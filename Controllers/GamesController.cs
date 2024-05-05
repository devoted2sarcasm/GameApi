using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameApi.Models;
using GameApi.Repositories;
using System.Collections.Generic;
using GameApi.Exceptions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GameApi.Controllers
{
    [ApiController]
    [EnableCors]
    public class BoardGamesController : ControllerBase
    {
        private readonly GameDbContext _context;

        public BoardGamesController(GameDbContext context)
        {
            _context = context;
        }

        [HttpGet("allGames", Name = "GetAllGames")]
        public List<BoardGame> GetAllGames()
        {
            if (this._context.BoardGames.Count() == 0)
            {
                // throw new System.Exception("No games found");
                throw new NotFoundException("No games found");
            }
            else
            {
                Console.WriteLine("Getting all games");
                Console.WriteLine("this._context.BoardGames", this._context.BoardGames);
                Console.WriteLine("this._context.BoardGames.ToList()", this._context.BoardGames.ToList());
                return this._context.BoardGames.ToList();            }
        }

        [HttpGet("games", Name = "GetGames")]
        public List<BoardGame> GetGames([FromQuery] string? name)
        {
            if (name != null)
            {
                string search = name.ToLower();
                return this._context.BoardGames
                    .Where(game => game.Name.ToLower().Contains(search))
                    .ToList();
            }
            else
            {
                return this._context.BoardGames.ToList();
            }
        }

        [HttpGet("games/{Id}", Name = "GetGameById")]
        public BoardGame? GetGameById(int Id)
        {
            return this._context.BoardGames
                .Where(game => game.Id == Id)
                .FirstOrDefault();
        }

        [HttpDelete("games/{Id}", Name = "DeleteGameById")]
        
        public void DeleteGameById(int Id)
        {
            BoardGame? gameToDelete = this._context.BoardGames.Find(Id);

            if (gameToDelete != null)
            {
                this._context.BoardGames.Remove(gameToDelete);
                this._context.SaveChanges();
            }
            else 
            {
                throw new System.Exception("Game not found");
            }
        }
        

        [HttpPost("games", Name = "AddGame")]
        public BoardGame CreateGame([FromBody] GameCreateRequest game)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidInput("Invalid request. ", ModelState);
            }
            else
            {
                BoardGame gameToCreate = new BoardGame
            {
                Name = game.Name,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
                Description = game.Description,
                Difficulty = game.Difficulty,
                Rank = game.Rank,
                IdealPlayerCount = game.IdealPlayerCount,
                Playtime = game.Playtime
            };

            this._context.BoardGames.Add(gameToCreate);
            this._context.SaveChanges();

            return gameToCreate;
            }
            
        }

        [HttpPut("games/{id}", Name = "UpdateGame")]
        public void UpdateBoardGame([FromBody] BoardGame game, int Id)
        {
            BoardGame? gameToUpdate = this._context.BoardGames.Find(Id);

            if (gameToUpdate != null)
            {
                gameToUpdate.Name = game.Name;
                gameToUpdate.MinPlayers = game.MinPlayers;
                gameToUpdate.MaxPlayers = game.MaxPlayers;
                gameToUpdate.Description = game.Description;
                gameToUpdate.Difficulty = game.Difficulty;
                gameToUpdate.Rank = game.Rank;
                gameToUpdate.IdealPlayerCount = game.IdealPlayerCount;
                gameToUpdate.Playtime = game.Playtime;

                this._context.SaveChanges();
            }
            else
            {
                throw new System.Exception("Game not found");
            }
        }
    }
}