using ErrorOr;
using TicTacToe.Api.Game.Models;

namespace TicTacToe.Api.Game.Interfaces;

public interface IGameRepository {

    Task<ErrorOr<Success>> SaveGameAsync(GameState game);
    Task<ErrorOr<List<GameState>>> ListGameStatesAsync();
    Task<ErrorOr<Deleted>> DeleteGame(GameState game);

}