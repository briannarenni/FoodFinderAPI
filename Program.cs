using FoodFinder.Data;
using FoodFinder.Models;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
string? connString = builder.Configuration.GetValue<string>("ConnectionStrings:FoodFinderDB");
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FoodFinderContext>(opts =>
    opts.UseSqlServer(connString)
);

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/restaurants", async (FoodFinderContext db) => await db.GetAllRestaurants());

app.MapGet("/restaurants/cuisine", async (FoodFinderContext db, string cuisine) => await db.GetByCuisine(cuisine));

app.MapGet("/restaurants/city", async (FoodFinderContext db, string city) => await db.GetByCity(city));

app.MapGet("/restaurants/rating", async (FoodFinderContext db) => await db.GetByHighestRating());

app.MapGet("/restaurants/rating-asc", async (FoodFinderContext db) => await db.GetByLowestRating());

app.MapGet("/restaurants/score", async (FoodFinderContext db) => await db.GetByHighestScore());

app.MapGet("/restaurants/score-desc", async (FoodFinderContext db) => await db.GetByLowestScore());

// app.MapGet("/menus", async (FoodFinderDB db) => await db.Players.ToListAsync());

app.Run();
