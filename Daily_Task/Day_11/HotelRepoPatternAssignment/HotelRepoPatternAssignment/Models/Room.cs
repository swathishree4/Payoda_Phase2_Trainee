using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HotelRepoPatternAssignment.Models
{
    public class Room
    {
        [Key]
        public int RoomNo { get; set; }

        public string RoomType { get; set; }
        [Range(5000, 200000, ErrorMessage = "Price should be between 5000 and 200000")]
        public double Price { get; set; }

        public int HotelId { get; set; }
        [ForeignKey("HotelId")]
        public Hotel? Hotel { get; set; }
    }
}
