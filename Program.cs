using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddDbContext<PlayerDB>(options => options.UseInMemoryDatabase("players"));
string? connString = builder.Configuration.GetValue<string>("ConnectionStrings:FoodFinderDB");

// App instance
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
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
