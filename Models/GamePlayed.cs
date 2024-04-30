using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GameApi.Models;

public class GamePlayed
{
    
    public int Id { get; set; }

    public int Players { get; set; }

    public int BoardGameId { get; set; }

    //public BoardGame BoardGame { get; set; }

    public string Timestamp { get; set; }

    public string Winner { get; set; }

    // public List<Score> Scores { get; set; }

    public string? Comments { get; set; }
}