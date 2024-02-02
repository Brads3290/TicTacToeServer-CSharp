using ErrorOr;
using TicTacToe.Api.Game.Models;

namespace TicTacToe.Api.Game.Interfaces;

public interface IGameRepository {

    Task<GameState?> GetGameAsync(string gameId);
    Task SaveGameAsync(GameState game);
    Task<List<GameState>> ListGameStatesAsync();
    Task DeleteGame(GameState game);

}