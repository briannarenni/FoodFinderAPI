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

// app.MapGet("/restaurants", async (FoodFinderDB db) => await db.Players.ToListAsync());
// app.MapGet("/ratings", async (FoodFinderDB db) => await db.Players.ToListAsync());
// app.MapGet("/menus", async (FoodFinderDB db) => await db.Players.ToListAsync());
// app.MapPost: return Results.Created($"/todo/player.playerId", player)
// app.MapPatch: return Results.NoContent();

app.Run();
