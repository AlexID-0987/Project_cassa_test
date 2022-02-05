using Microsoft.EntityFrameworkCore;

namespace Project_cassa_test.Models
{
    public class PurchaseContext:DbContext
    {
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Order> Orders { get; set; }
        public PurchaseContext(DbContextOptions<PurchaseContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
