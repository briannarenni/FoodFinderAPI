using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// Id: an integer property that represents the primary key column in the Restaurant table.
// RestName: a string property that represents the rest_name column in the Restaurant table.
// Cuisine: a string property that represents the cuisine column in the Restaurant table.
// City: a string property that represents the city column in the Restaurant table.
// Rating: a collection of Rating entities that represents the relationship between the Restaurant and Rating entities

// Id, RestName, Cuisine, City, Rating
// Cuisines: American, Chinese, Greek, Italian, Mexican, Thai
// Cities: Atlanta, Chicago, Houston, LA, Miami, New Orleans,
// NYC, Orlando, Portland, Seattle, San Diego, San Fran

namespace FoodFinder.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestName { get; set; }
        public string Cuisine { get; set; }
        public string City { get; set; }
        public RestaurantRating Rating { get; set; }
    }

    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id");
            builder.Property(r => r.RestName).HasColumnName("rest_name").IsRequired().HasMaxLength(100);
            builder.Property(r => r.Cuisine).HasColumnName("cuisine").IsRequired().HasMaxLength(50);
            builder.Property(r => r.City).HasColumnName("city").IsRequired().HasMaxLength(50);
        }
    }
}
