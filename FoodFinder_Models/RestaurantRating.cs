using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinder.Models
{
public class RestaurantRating
    {
        public int Score { get; set; }
        public char Grade { get; set; }
    }

}
