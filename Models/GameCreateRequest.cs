using System.ComponentModel.DataAnnotations;

namespace GameApi.Models
{
    public class GameCreateRequest
    {
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [MaxLength(50, ErrorMessage = "Name must be at most 50 characters long")]
        [Required]
        public string Name { get; set; }

        [Range(1, 100, ErrorMessage = "MinPlayers must be between 1 and 100")]
        [Required]
        public int MinPlayers { get; set; }

        [Range(1, 100, ErrorMessage = "MaxPlayers must be between 1 and 100")]
        [Required]
        //attribute to ensure max players is more than min players
        //[Compare("MinPlayers", ErrorMessage = "MaxPlayers must be greater than MinPlayers")]
        public int MaxPlayers { get; set; }

        [MaxLength(100, ErrorMessage = "Description must be at most 100 characters long")]
        public string? Description { get; set; }

        [Range(1, 10, ErrorMessage = "Difficulty must be between 1 and 10")]
        public int? Difficulty { get; set; }

        [Range(1, 9999, ErrorMessage = "Rank must be between 1 and 9999")]
        public int? Rank { get; set; }

        [Range(1, 100, ErrorMessage = "IdealPlayerCount must be between 1 and 100")]
        public int? IdealPlayerCount { get; set; }

        [Range(1, 1000, ErrorMessage = "Playtime must be between 1 and 1000")]
        public int? Playtime { get; set; }



    }
}