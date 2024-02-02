using TicTacToe.Api.Games.Interfaces;
using TicTacToe.Api.Games.Models;

namespace TicTacToe.Api.Games.Repositories;

public class InMemoryGameRepository : IGameRepository
{
    private readonly Dictionary<string, Game> _games = new();
    
    public Task DeleteGame(Game game)
    {
        _games.Remove(game.Id);
        return Task.CompletedTask;
    }

    public Task<Game?> GetGameAsync(string gameId)
    {
        _games.TryGetValue(gameId, out var game);

        return Task.FromResult(game);

    }

    public Task<List<Game>> ListGameStatesAsync()
    {
        return Task.FromResult(_games.Values.ToList());
    }

    public Task SaveGameAsync(Game game)
    {
        _games[game.Id] = game;
        return Task.CompletedTask;
    }
}