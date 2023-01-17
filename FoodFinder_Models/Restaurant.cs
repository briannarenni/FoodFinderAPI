using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// CITIES: Atlanta, Chicago, Houston, Los Angeles, Miami, New Orleans,
// New York City, Orlando, Portland, Seattle, San Diego, San Francisco

namespace FoodFinder.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string RestName { get; set; }
        public string Cuisine { get; set; }
        public string City { get; set; }
        public char Grade { get; set; }
        public int Rating { get; set; }

        public Restaurant() {}

        public Restaurant(int id, string restName, string cuisine, string city, char grade, int rating)
        {
            Id = id;
            RestName = restName;
            Cuisine = cuisine;
            City = city;
            Grade = grade;
            Rating = rating;
        }
    }

    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant_Rating");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(r => r.RestName).HasColumnName("rest_name").IsRequired().HasMaxLength(100);
            builder.Property(r => r.Cuisine).HasColumnName("cuisine").IsRequired().HasMaxLength(50);
            builder.Property(r => r.City).HasColumnName("city").IsRequired().HasMaxLength(50);
            builder.Property(r => r.Grade).HasColumnName("grade").IsRequired();
            builder.Property(r => r.Rating).HasColumnName("rating").IsRequired();
        }
    }
}
