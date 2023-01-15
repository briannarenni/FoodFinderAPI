using FoodFinder.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodFinder.Data
{
    public class FoodFinderContext : DbContext
    {
        public FoodFinderContext(DbContextOptions<FoodFinderContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<RestaurantRating> RestaurantRating { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantConfiguration());
            // ! MAKE VIEW WITH RATING IN SQL TO QUERY
            // builder.Entity<Restaurant>()
            //     .HasOne(p => p.RestaurantRating)
            //     .WithOne(b => b.Restaurant)
            //     .HasForeignKey<RestaurantRating>(b => b.RestaurantId);
        }

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await Restaurant.Include(r => r.RestaurantRating).ToListAsync();
        }

        public async Task<List<Restaurant>> GetByHighestRating()
        {
            return await Restaurant
                .Include(r => r.RestaurantRating)
                .OrderByDescending(r => r.RestaurantRating.Score)
                .Take(10)
                .ToListAsync();
        }
    }

}

