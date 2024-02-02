using TicTacToe.Api.Games.Models;

namespace TicTacToe.Api.Games.Interfaces;

public interface IGameRepository {

    Task<Game?> GetGameAsync(string gameId);
    Task SaveGameAsync(Game game);
    Task<List<Game>> ListGameStatesAsync();
    Task DeleteGame(Game game);

}