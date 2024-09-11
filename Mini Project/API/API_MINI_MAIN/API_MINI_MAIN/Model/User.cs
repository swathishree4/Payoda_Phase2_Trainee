using System.ComponentModel.DataAnnotations;

namespace API_MINI_MAIN.Model
{
    public class User
    {

        [Key]
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? email { get; set; }
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
