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
    builder.Configuration.AddUserSecrets<Program>();
}

// TODO: Get all restaurants alphabetically
// app.MapGet("/restaurants", async (FoodFinderDB db) => await db.Players.ToListAsync());

// TODO: Get all restaurants by cuisine, alphabetical

// TODO: Get all restaurants by given city

// TODO: Get all restaurants by highest rating

// TODO: Get all restaurants

// TODO: Get all restaurants

// TODO: Get all restaurants

// app.MapGet("/ratings", async (FoodFinderDB db) => await db.Players.ToListAsync());
// app.MapGet("/menus", async (FoodFinderDB db) => await db.Players.ToListAsync());

app.Run();
