using FoodFinder.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FoodFinder.Data
{
    public class FoodFinderContext : DbContext
    {
        public FoodFinderContext(DbContextOptions<FoodFinderContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurant { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantConfiguration());
        }

        private static Restaurant RestModel(Restaurant restaurant)
        {
            return new Restaurant
            {
                RestName = restaurant.RestName,
                Cuisine = restaurant.Cuisine,
                City = restaurant.City,
                Grade = restaurant.Grade,
                Score = restaurant.Score
            };
        }

        public async Task<string> GetAllRestaurants()
        {
            var restaurants = await Restaurant.OrderBy(x => x.Cuisine).ThenBy(x => x.RestName).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByCuisine(string cuisine)
        {
            var restaurants = await Restaurant.Where(x => x.Cuisine == cuisine).OrderBy(x => x.Cuisine).ThenBy(x => x.RestName).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByCity(string city)
        {
            var restaurants = await Restaurant.Where(x => x.City == city).OrderBy(x => x.Cuisine).ThenBy(x => x.RestName).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByHighestRating()
        {
            var restaurants = await Restaurant.OrderByDescending(x => x.Grade).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByLowestRating()
        {
            var restaurants = await Restaurant.OrderBy(x => x.Grade).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByHighestScore()
        {
            var restaurants = await Restaurant.OrderByDescending(x => x.Score).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }

        public async Task<string> GetByLowestScore()
        {
            var restaurants = await Restaurant.OrderBy(x => x.Score).Select(r => RestModel(r)).ToListAsync();
            return JsonConvert.SerializeObject(restaurants);
        }
    }
}
