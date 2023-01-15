using FoodFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFinder.Data
{
    public class FoodFinderContext : DbContext
    {
        public FoodFinderContext(DbContextOptions<FoodFinderContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Rating> Rating { get; set; }
        // public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());

        }
    }
}
