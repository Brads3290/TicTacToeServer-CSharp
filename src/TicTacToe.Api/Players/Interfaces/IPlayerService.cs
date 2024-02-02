using ErrorOr;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Interfaces;

public interface IPlayerService {
    
    Task<ErrorOr<Player>> CreatePlayerAsync(string nickname);
    Task<ErrorOr<Player>> GetPlayerAsync(string id);

}

public static class PlayerServiceErrors {

    public static Error NicknameTaken = Error.Conflict(
        code: "PlayerService.NicknameTaken",
        description: "Nickname is in use");

    public static Error PlayerNotFound = Error.NotFound(
        code: "PlayerService.PlayerNotFound",
        description: "Player is not found");

}