using System.ComponentModel.DataAnnotations;

namespace Apiproject.Model
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int TotalPoints { get; set; }
        public int TotalAssists { get; set; }
        public int TotalRebounds { get; set; }
        public ICollection<Game>? Games { get; set; }
    }
}
