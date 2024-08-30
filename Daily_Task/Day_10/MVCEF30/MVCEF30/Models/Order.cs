using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcefcodefirst.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public string? ProductName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int id {  get; set; }

        [ForeignKey("id")]
        public Customer? Customer { get; set; }

    }
}
