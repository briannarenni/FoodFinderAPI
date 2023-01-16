using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// Id, RestName, Cuisine, City, Rating
// Cuisines: American, Chinese, Greek, Italian, Mexican, Thai
// Cities: Atlanta, Chicago, Houston, LA, Miami, New Orleans,
// NYC, Orlando, Portland, Seattle, San Diego, San Fran

namespace FoodFinder.Models
{
    public class Restaurant
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string RestName { get; set; }
        public string Cuisine { get; set; }
        public string City { get; set; }
        public char Grade { get; set; }
        public int Score { get; set; }

        public Restaurant() {}

        public Restaurant(string restName, string cuisine, string city, char grade, int score)
        {
            RestName = restName;
            Cuisine = cuisine;
            City = city;
            Grade = grade;
            Score = score;
        }
    }

    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.ToTable("Restaurant_Rating");
            builder.HasKey(r => r.Id);
            builder.Ignore(r => r.Id);
            builder.Property(r => r.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(r => r.RestName).HasColumnName("rest_name").IsRequired().HasMaxLength(100);
            builder.Property(r => r.Cuisine).HasColumnName("cuisine").IsRequired().HasMaxLength(50);
            builder.Property(r => r.City).HasColumnName("city").IsRequired().HasMaxLength(50);
            builder.Property(r => r.Grade).HasColumnName("grade").IsRequired();
            builder.Property(r => r.Score).HasColumnName("score").IsRequired();
        }
    }
}
