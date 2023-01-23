using FoodFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FoodFinderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("foodfinder-connString")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("*")
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

app.UseCors();

app.MapGet("/restaurants", async (FoodFinderContext db) => await db.GetAllRestaurants());

app.MapGet("/restaurants/cuisine", async (FoodFinderContext db, string cuisine) => await db.FilterByCuisine(cuisine));

app.MapGet("/restaurants/city", async (FoodFinderContext db, string city) => await db.FilterByCity(city));

app.MapGet("/restaurants/rating", async (FoodFinderContext db) => await db.GetByHighestRating());

app.MapGet("/restaurants/rating-low", async (FoodFinderContext db) => await db.GetByLowestRating());

app.MapGet("/menus/cuisine", async (FoodFinderContext db, string cuisine) => await db.GetMenu(cuisine));

app.Run();
