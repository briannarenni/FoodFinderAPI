using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// RatingId, RestId, Grade, Score, ScoreDate, Restaurant

// RatingId: an integer property that represents the primary key column in the Rating table
// RestId: an integer property that represents the foreign key column in the Rating table, referencing the id column in the Restaurant table
// Grade: a char property that represents the grade column in the Rating table
// Score: an integer property that represents the score column in the Rating table
// ScoreDate: a date property that represents the score_date column in the Rating table
// Restaurant: a Restaurant property that represents the relationship between the Rating and Restaurant entities

namespace FoodFinder.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int RestId { get; set; }
        public char Grade { get; set; }
        public int Score { get; set; }
        public DateTime ScoreDate { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }

    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> builder)
        {
            builder.ToTable("Rating");
            builder.HasKey(r => r.RatingId);
            builder.Property(r => r.RatingId).HasColumnName("rating_id").ValueGeneratedOnAdd();
            builder.Property(r => r.RestId).HasColumnName("rest_id").IsRequired();
            builder.Property(r => r.Grade).HasColumnName("grade").IsRequired();
            builder.Property(r => r.Score).HasColumnName("score").IsRequired();
            builder.Property(r => r.ScoreDate).HasColumnName("score_date").IsRequired();
            builder.HasOne(r => r.Restaurant)
                .WithOne(r => r.Rating)
                .HasForeignKey<Rating>(r => r.RestId);
        }
    }
}
