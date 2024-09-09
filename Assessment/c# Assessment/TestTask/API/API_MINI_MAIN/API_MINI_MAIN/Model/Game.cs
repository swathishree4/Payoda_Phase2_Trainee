using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Apiproject.Model
{
    public class Game
    {
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public string? Opponent { get; set; }
        public int Attendance { get; set; }

        public int PlayerId { get; set; }

        [ForeignKey("PlayerId")]
        public Player? Player { get; set; }
    }
}
