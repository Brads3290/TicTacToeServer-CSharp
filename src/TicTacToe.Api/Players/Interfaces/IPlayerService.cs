using ErrorOr;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Interfaces;

public interface IPlayerService {

    Task<ErrorOr<Player>> CreatePlayerAsync(string nickname);

}

public static class PlayerServiceErrors {

    public static Error NicknameTaken = Error.Conflict(
        code: "PlayerService.NicknameTaken",
        description: "Nickname is in use");

}