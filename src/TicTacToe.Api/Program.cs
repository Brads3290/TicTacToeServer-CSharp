using TicTacToe.Api;
using TicTacToe.Api.Games.Interfaces;
using TicTacToe.Api.Games.Repositories;
using TicTacToe.Api.Games.Services;
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
builder.Services.AddSingleton<IPlayerRepository, JsonPlayerRepository>();
builder.Services.AddSingleton<IGameRepository, JsonGameRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("swagger/v1/swagger.json", "TicTacToe");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();