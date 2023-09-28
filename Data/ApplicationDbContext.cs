using Microsoft.EntityFrameworkCore;
using SafeSkull.Models;

namespace SafeSkull.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Brand> Brands { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasKey(b => b.Id);
            
        }
    }
}
