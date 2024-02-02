using TicTacToe.Api.Common;
using TicTacToe.Api.Games.Interfaces;
using TicTacToe.Api.Games.Models;

namespace TicTacToe.Api.Games.Repositories;

public class JsonGameRepository : JsonRepositoryBase, IGameRepository {

    private Dictionary<string, Game>? _games;
    private const string Filename = "games.json";

    public async Task DeleteGame(Game game) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Game>>(Filename);
        }
        
        _games.Remove(game.Id);
        await SaveFile(Filename, _games);
    }

    public async Task<Game?> GetGameAsync(string gameId) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Game>>(Filename);
        }
        
        _games.TryGetValue(gameId, out var game);
        return game;

    }

    public async Task<List<Game>> ListGameStatesAsync() {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Game>>(Filename);
        }

        return _games.Values.ToList();
    }

    public async Task SaveGameAsync(Game game) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Game>>(Filename);
        }
        
        _games[game.Id] = game;
        await SaveFile(Filename, _games);
    }
    
}