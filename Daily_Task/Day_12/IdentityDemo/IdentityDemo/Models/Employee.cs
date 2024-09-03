using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string? Name { get; set; }
    }
}
