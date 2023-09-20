using Microsoft.EntityFrameworkCore;
using CustomerListAPI.Models;
namespace CustomerListAPI.Models
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) 
            : base(options) 
        {
        }
        public virtual DbSet<Customer> Customers { get; set;}
    }
}
