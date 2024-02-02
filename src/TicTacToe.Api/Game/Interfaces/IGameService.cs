using ErrorOr;
using TicTacToe.Api.Game.Models;

namespace TicTacToe.Api.Game.Interfaces;

public interface IGameService {

    Task<ErrorOr<GameState>> StartGameAsync();
    Task<ErrorOr<List<GameState>>> ListOpenGamesAsync();
    Task<ErrorOr<GameState>> GetGameStateAsync();
    Task<ErrorOr<GameState>> ResignGameAsync();

}

public static class GameServiceErrors {

    public static Error GameNotFound = Error.NotFound(
        code: "GameService.NotFound",
        description: "Game not found");
    
    

} 