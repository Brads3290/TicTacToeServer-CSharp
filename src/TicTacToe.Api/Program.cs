using TicTacToe.Api;
using TicTacToe.Api.Game.Interfaces;
using TicTacToe.Api.Game.Services;
using TicTacToe.Api.Players.Interfaces;
using TicTacToe.Api.Players.Repositories;
using TicTacToe.Api.Players.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddSingleton<IPlayerRepository, InMemoryPlayerRepository>();
builder.Services.AddSingleton<IGameRepository, InMemoryGameRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();

namespace TicTacToe.Api {

    record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary) {

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    }

}