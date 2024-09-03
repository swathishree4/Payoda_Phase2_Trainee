using System.ComponentModel.DataAnnotations;

namespace HotelRepoPatternAssignment.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        [StringLength(30, ErrorMessage = "Hotel Name is minimum 10 character", MinimumLength = 5)]
        public string HotelName { get; set; }

        public ICollection<Room>? Rooms { get; set; }
    }
}
