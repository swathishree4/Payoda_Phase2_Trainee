using System.ComponentModel.DataAnnotations;

namespace mvcefcodefirst.Models
{
    public class Customer
    {
        [Key]
        public int id { set; get; } 
        public string? name { set; get; }    

        public string? email { set; get; }  

        public string? location { set; get; }

        public List<Order>? orders { set; get; }
    }
}
