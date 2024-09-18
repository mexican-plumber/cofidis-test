using CofidisTest.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CofidisTest.Data
{
    public class CofidistTestContext : DbContext
    {
        public CofidistTestContext(DbContextOptions<CofidistTestContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
