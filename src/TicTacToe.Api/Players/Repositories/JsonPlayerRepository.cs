using TicTacToe.Api.Common;
using TicTacToe.Api.Players.Interfaces;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Repositories;

public class JsonPlayerRepository : JsonRepositoryBase, IPlayerRepository {

    private Dictionary<string, Player>? _players;
    private const string Filename = "players.json";

    public async Task<Player?> GetPlayerAsync(string playerId) {
        if (_players is null) {
            _players = await LoadFile<Dictionary<string, Player>>(Filename);
        }

        _players.TryGetValue(playerId, out var player);
        return player;
    }

    public async Task<Player?> GetPlayerByNicknameAsync(string nickname) {
        if (_players is null) {
            _players = await LoadFile<Dictionary<string, Player>>(Filename);
        }

        var player = _players.Values.FirstOrDefault(x => x.Nickname == nickname);
        return player;
    }

    public async Task SavePlayerAsync(Player player) {
        if (_players is null) {
            _players = await LoadFile<Dictionary<string, Player>>(Filename);
        }

        _players[player.Id] = player;

        await SaveFile(Filename, _players);
    }

    public async Task<List<Player>> ListPlayersAsync() {
        if (_players is null) {
            _players = await LoadFile<Dictionary<string, Player>>(Filename);
        }

        return _players.Values.ToList();
    }

    public async Task DeletePlayer(Player player) {
        if (_players is null) {
            _players = await LoadFile<Dictionary<string, Player>>(Filename);
        }

        _players.Remove(player.Id);

        await SaveFile(Filename, _players);
    }

}