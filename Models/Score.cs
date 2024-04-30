using Microsoft.EntityFrameworkCore;

namespace GameApi.Models;

public class Score
{
    
    public int Id { get; set; }
    public string Player { get; set; }

    public int PlayerScore { get; set; }

    public int GamePlayedId { get; set; }

    public GamePlayed GamePlayed { get; set; }
}