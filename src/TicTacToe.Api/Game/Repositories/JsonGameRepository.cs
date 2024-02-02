using Newtonsoft.Json;
using TicTacToe.Api.Common;
using TicTacToe.Api.Game.Interfaces;

namespace TicTacToe.Api.Game.Repositories;

public class JsonGameRepository : JsonRepositoryBase, IGameRepository {

    private Dictionary<string, Models.Game>? _games;
    private const string Filename = "games.json";

    public async Task DeleteGame(Models.Game game) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Models.Game>>(Filename);
        }
        
        _games.Remove(game.Id);
        await SaveFile(Filename, _games);
    }

    public async Task<Models.Game?> GetGameAsync(string gameId) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Models.Game>>(Filename);
        }
        
        _games.TryGetValue(gameId, out var game);
        return game;

    }

    public async Task<List<Models.Game>> ListGameStatesAsync() {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Models.Game>>(Filename);
        }

        return _games.Values.ToList();
    }

    public async Task SaveGameAsync(Models.Game game) {
        if (_games is null) {
            _games = await LoadFile<Dictionary<string, Models.Game>>(Filename);
        }
        
        _games[game.Id] = game;
        await SaveFile(Filename, _games);
    }
    
}