using System.ComponentModel.DataAnnotations;

namespace GameApi.Models
{
    public class PlayGameCreateRequest
    {
        [Required]
        [Range(1, 100, ErrorMessage = "Players must be between 1 and 100")]
        public int Players { get; set; }
        
        [Required]
        public int BoardGameId { get; set; }
        
        [Required]
        public string Timestamp { get; set; }
        
        [Required]
        public string Winner { get; set; }
        
        public string? Comments { get; set; }
    }
}