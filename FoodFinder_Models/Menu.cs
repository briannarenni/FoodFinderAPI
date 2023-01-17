using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodFinder.Models
{

    public class Menu
    {
        public int ItemId { get; set; }
        public string Cuisine { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemGroup { get; set; }

        public Menu() { }

        public Menu(int item_id, string cuisine, string item_name, decimal item_price, string item_group)
        {
            ItemId = item_id;
            Cuisine = cuisine;
            ItemName = item_name;
            ItemPrice = item_price;
            ItemGroup = item_group;
        }
    }

    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            builder.HasKey(r => r.ItemId);
            builder.Property(r => r.ItemId).HasColumnName("item_id");
            builder.Property(r => r.Cuisine).HasColumnName("cuisine").IsRequired();
            builder.Property(r => r.ItemName).HasColumnName("item_name").IsRequired();
            builder.Property(r => r.ItemPrice).HasColumnName("item_price").IsRequired();
            builder.Property(r => r.ItemGroup).HasColumnName("item_group").IsRequired();
        }
    }
}
