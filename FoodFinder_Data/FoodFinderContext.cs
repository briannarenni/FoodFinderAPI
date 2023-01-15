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

        public async Task<List<Restaurant>> GetAllRestaurants()
        {
            return await Restaurant
                .Include(r => r.Rating)
                .Select(r => new Restaurant
                {
                    Id = r.Id,
                    RestName = r.RestName,
                    Cuisine = r.Cuisine,
                    City = r.City,
                    Rating = new RestaurantRating { Score = r.Rating.Score, Grade = r.Rating.Grade }
                })
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetByHighestRating()
        {
            return await Restaurant
                .Include(r => r.Rating)
                .Select(r => new Restaurant
                {
                    Id = r.Id,
                    RestName = r.RestName,
                    Cuisine = r.Cuisine,
                    City = r.City,
                    Rating = new RestaurantRating { Score = r.Rating.Score, Grade = r.Rating.Grade }
                })
                .OrderByDescending(r => r.Rating.Score)
                .Take(10)
                .ToListAsync();
        }

    }
}
