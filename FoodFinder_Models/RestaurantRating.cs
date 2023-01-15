using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// ! MAKE VIEW WITH RATING IN SQL TO QUERY
namespace FoodFinder.Models
{
public class RestaurantRating
    {
        public int Score { get; set; }
        public char Grade { get; set; }
        public Restaurant Restaurant { get; internal set; }
    }

    public class RestaurantRatingConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {

        }
    }

}
