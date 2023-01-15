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

// TODO: Get all restaurants alphabetically
// app.MapGet("/restaurants", async (FoodFinderContext db) => await db.Restaurants.ToListAsync());
app.MapGet("/restaurants", async (FoodFinderContext db) => await db.Restaurant.AsQueryable().ToListAsync());

// TODO: Get all restaurants by cuisine, alphabetical

// TODO: Get all restaurants by given city (string)

// TODO: Get all restaurants by highest rating

// TODO: Get all restaurants by lowest rating

// TODO: Get all restaurants by highest score

// TODO: Get all restaurants by lowest score

// app.MapGet("/ratings", async (FoodFinderDB db) => await db.Players.ToListAsync());
// app.MapGet("/menus", async (FoodFinderDB db) => await db.Players.ToListAsync());

app.Run();
