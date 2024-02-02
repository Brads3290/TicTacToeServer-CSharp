using ErrorOr;
using TicTacToe.Api.Game.Models;

namespace TicTacToe.Api.Game.Interfaces;

public interface IGameRepository {

    Task<Models.Game?> GetGameAsync(string gameId);
    Task SaveGameAsync(Models.Game game);
    Task<List<Models.Game>> ListGameStatesAsync();
    Task DeleteGame(Models.Game game);

}