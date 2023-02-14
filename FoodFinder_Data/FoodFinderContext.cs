using FoodFinder.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FoodFinder.Data
{
    public class FoodFinderContext : DbContext
    {
        public FoodFinderContext(DbContextOptions<FoodFinderContext> options) : base(options) { }

        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Menu> Menu { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RestaurantConfiguration());
            builder.ApplyConfiguration(new MenuConfiguration());
        }

        public async Task<string> GetAllRestaurants()
        {
            var restaurants = await Restaurant.OrderBy(x => x.RestName).Select(r => r).ToListAsync();
            return JsonConvert.SerializeObject(restaurants, Formatting.Indented);
        }

        public async Task<string> FilterByCuisine(string cuisine)
        {
            var restaurants = await Restaurant.Where(x => x.Cuisine == cuisine).OrderBy(x => x.Cuisine).ThenByDescending(x => x.Rating).ThenBy(x => x.RestName).ToListAsync();
            return JsonConvert.SerializeObject(restaurants, Formatting.Indented);
        }

        public async Task<string> FilterByCity(string city)
        {
            var restaurants = await Restaurant.Where(x => x.City == city).OrderBy(x => x.Cuisine).ThenByDescending(x => x.Rating).ThenBy(x => x.RestName).ToListAsync();
            return JsonConvert.SerializeObject(restaurants, Formatting.Indented);
        }

        public async Task<string> GetByHighestRating()
        {
            var restaurants = await Restaurant.OrderByDescending(x => x.Rating).ToListAsync();
            return JsonConvert.SerializeObject(restaurants, Formatting.Indented);
        }

        public async Task<string> GetByLowestRating()
        {
            var restaurants = await Restaurant.OrderBy(x => x.Rating).ToListAsync();
            return JsonConvert.SerializeObject(restaurants, Formatting.Indented);
        }

        public async Task<string> GetMenu(string cuisine)
        {
            var menu = await Menu.Where(m => m.Cuisine == cuisine).OrderBy(m => m.ItemGroup).ToListAsync();
            return JsonConvert.SerializeObject(menu, Formatting.Indented);
        }

        public async Task<string> GetAllMenus()
        {
            var menu = await Menu.OrderBy(m => m.ItemGroup).ToListAsync();
            return JsonConvert.SerializeObject(menu, Formatting.Indented);
        }
    }
}

// public async Task SeedMenuData(){if (!Menu.Any()){ Menu.AddRange(SeedData.menuItems);  await SaveChangesAsyc();  } }

