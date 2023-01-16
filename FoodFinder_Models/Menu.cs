using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

// COLUMNS: item_id, cuisine, item_name, item_price, item_group
// CUISINES: American, Chinese, Greek, Italian, Mexican, Thai

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

        public static readonly List<Menu> menuItems = new List<Menu>
        {
            new Menu { Cuisine = "Mexican", ItemName = "Chips and Guacamole", ItemPrice = 4.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "Mexican", ItemName = "Chips and Queso Dip", ItemPrice = 5.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "Mexican", ItemName = "Tacos", ItemPrice = 15.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Mexican", ItemName = "Burrito", ItemPrice = 18.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Mexican", ItemName = "Enchiladas", ItemPrice = 21.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Italian", ItemName = "Bruschetta", ItemPrice = 4.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "Italian", ItemName = "Caprese Salad", ItemPrice = 5.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "Italian", ItemName = "Lasagna", ItemPrice = 18.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Italian", ItemName = "Spaghetti Bolognese", ItemPrice = 20.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Italian", ItemName = "Pizza Margherita", ItemPrice = 21.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "American", ItemName = "Fried Mozzarella Sticks", ItemPrice = 6.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "American", ItemName = "Buffalo Wings", ItemPrice = 8.99m, ItemGroup = "appetizer" },
            new Menu { Cuisine = "American", ItemName = "Cheeseburger", ItemPrice = 12.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "American", ItemName = "Steak", ItemPrice = 25.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "American", ItemName = "Fried Chicken", ItemPrice = 16.99m, ItemGroup = "entree" },
            new Menu { Cuisine = "Chinese", ItemName = "Egg Rolls", ItemPrice = 4.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Chinese", ItemName = "Wontons", ItemPrice = 5.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Chinese", ItemName = "Kung Pao Chicken", ItemPrice = 12.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Chinese", ItemName = "Fried Rice", ItemPrice = 8.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Chinese", ItemName = "Moo Shu Pork", ItemPrice = 18.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Chinese", ItemName = "Hot and Sour Soup", ItemPrice = 6.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Greek", ItemName = "Spanakopita", ItemPrice = 4.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Greek", ItemName = "Dolmades", ItemPrice = 5.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Greek", ItemName = "Gyro", ItemPrice = 12.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Greek", ItemName = "Moussaka", ItemPrice = 18.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Greek", ItemName = "Souvlaki", ItemPrice = 14.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Greek", ItemName = "Greek Salad", ItemPrice = 6.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Thai", ItemName = "Spring Rolls", ItemPrice = 4.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Thai", ItemName = "Tom Yum Soup", ItemPrice = 5.99m, ItemGroup = "appetizer" },
new Menu { Cuisine = "Thai", ItemName = "Pad Thai", ItemPrice = 12.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Thai", ItemName = "Green Curry", ItemPrice = 18.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Thai", ItemName = "Tom Kha Gai", ItemPrice = 14.99m, ItemGroup = "entree" },
new Menu { Cuisine = "Thai", ItemName = "Papaya Salad", ItemPrice = 6.99m, ItemGroup = "entree" },

        };

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
