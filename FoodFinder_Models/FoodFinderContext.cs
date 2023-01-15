using System.Transactions;
using Microsoft.EntityFrameworkCore;

namespace FoodFinder.Models
{
    public class FoodFinderContext : DbContext
    {
        public FoodFinderContext(DbContextOptions<FoodFinderContext> options)
          : base(options)
        {

        }
        public DbSet<Restaurant> Users { get; set; }  // = null!;
        public DbSet<Rating> Account { get; set; }  // = null!;
        public DbSet<Menu> Transaction { get; set; } // = null!;

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Restaurant>(e =>
        //     { e.ToTable("Restaurant"); });

        //     modelBuilder.Entity<Rating>(e =>
        //     { e.ToTable("Account"); });

        //     modelBuilder.Entity<Menu>(e =>
        //     { e.ToTable("Transaction"); });
        // }

    }
}
