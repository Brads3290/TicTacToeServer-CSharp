using ErrorOr;

namespace TicTacToe.Api.Game.Interfaces;

public interface IGameService {

    Task<ErrorOr<Models.Game>> StartGameAsync(string playerId);
    Task<ErrorOr<List<Models.Game>>> ListOpenGamesAsync();
    Task<ErrorOr<Models.Game>> GetGameStateAsync(string id);
    Task<ErrorOr<Models.Game>> MakeMoveAsync(string gameId, string playerId, int row, int col);
    Task<ErrorOr<Models.Game>> ResignGameAsync(string gameId, string playerId);
    Task<ErrorOr<Models.Game>> JoinGameAsync(string gameId, string playerId);

}

public static class GameServiceErrors {

    public static Error GameNotFound = Error.NotFound(
        code: "GameService.NotFound",
        description: "Game not found");

    public static Error PlayerNotFound = Error.NotFound(
        code: "GameService.PlayerNotFound",
        description: "Player not found");

    public static Error PlayerNotInGame = Error.Failure(
        code: "GameService.PlayerNotInGame",
        description: "This player is not in this game");

    public static Error PlayerAlreadyInGame = Error.Failure(
        code: "GameService.PlayerAlreadyInGame",
        description: "This player is already in this game");

    public static Error GameFull = Error.Failure(
        code: "GameService.GameFull",
        description: "This game already has two players");

    public static Error GameFinished = Error.Failure(
        code: "GameService.GameFinished",
        description: "This game is already finished");

    public static Error GameNotJoinable = Error.Failure(
        code: "GameService.GameNotJoinable",
        description: "This game is not in a joinable state");

    public static Error InvalidMove = Error.Failure(
        code: "GameService.InvalidMove",
        description: "The requested move is invalid");

} 