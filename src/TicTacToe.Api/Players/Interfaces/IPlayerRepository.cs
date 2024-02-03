using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Interfaces;

public interface IPlayerRepository {

    Task<Player?> GetPlayerAsync(string playerId);
    Task<Player?> GetPlayerByNicknameAsync(string nickname);
    Task SavePlayerAsync(Player player);
    Task<List<Player>> ListPlayersAsync();
    Task DeletePlayer(Player player);

}