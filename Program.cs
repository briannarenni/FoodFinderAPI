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

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/restaurants", async (FoodFinderContext db) => await db.GetAllRestaurants());

app.MapGet("/restaurants/cuisine", async (FoodFinderContext db, string cuisine) => await db.FilterByCuisine(cuisine));

app.MapGet("/restaurants/city", async (FoodFinderContext db, string city) => await db.FilterByCity(city));

app.MapGet("/restaurants/rating", async (FoodFinderContext db) => await db.GetByHighestRating());

app.MapGet("/restaurants/rating-asc", async (FoodFinderContext db) => await db.GetByLowestRating());

app.MapGet("/restaurants/score", async (FoodFinderContext db) => await db.GetByHighestScore());

app.MapGet("/restaurants/score-asc", async (FoodFinderContext db) => await db.GetByLowestScore());

app.MapGet("/menus/cuisine", async (FoodFinderContext db, string cuisine) => await db.GetMenu(cuisine));

// app.MapGet("/menu", async (FoodFinderContext db) => await db.GetAllMenus());
// app.MapPost("/menus", async (FoodFinderContext db) => await db.SeedMenuData());

app.UseCors();

app.Run();
