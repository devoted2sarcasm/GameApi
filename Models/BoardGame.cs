using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Models;

public class BoardGame
{
    
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; }

    public int MinPlayers { get; set; }

    public int MaxPlayers { get; set; }

    [MaxLength(100)]
    public string? Description { get; set; }

    public int? Difficulty { get; set; }

    public int? Rank { get; set; }

    public int? IdealPlayerCount { get; set; }

    public int? Playtime { get; set; }

    public List<GamePlayed> GamesPlayed { get; set; }

    
}