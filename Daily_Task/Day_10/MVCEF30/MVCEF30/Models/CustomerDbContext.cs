using Microsoft.EntityFrameworkCore;

namespace mvcefcodefirst.Models
{
    public class CustomerDbContext: DbContext
    {
        public DbSet<Customer> Customers { set; get; }
        public DbSet<Order> Order { set; get; }
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options):base(options)
        {

        }
    }
}
