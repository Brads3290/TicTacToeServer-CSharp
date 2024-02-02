using TicTacToe.Api.Players.Interfaces;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Repositories;

public class InMemoryPlayerRepository : IPlayerRepository {

    private readonly Dictionary<string, Player> _players = new();
    
    public Task<Player?> GetPlayerAsync(string playerId) {
        _players.TryGetValue(playerId, out var player);
        return Task.FromResult(player);
    }

    public Task<Player?> GetPlayerByNicknameAsync(string nickname) {
        var player = _players.Values.FirstOrDefault(x => x.Nickname == nickname);
        return Task.FromResult(player);
    }

    public Task SavePlayerAsync(Player player) {
        _players[player.Id] = player;
        return Task.CompletedTask;
    }

    public Task<List<Player>> ListPlayersAsync() {
        return Task.FromResult(_players.Values.ToList());
    }

    public Task DeletePlayer(Player player) {
        _players.Remove(player.Id);
        return Task.CompletedTask;
    }

}