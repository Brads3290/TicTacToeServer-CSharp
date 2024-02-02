using ErrorOr;
using TicTacToe.Api.Game.Models;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Interfaces;

public interface IPlayerRepository {

    Task<ErrorOr<Success>> SavePlayerAsync(Player game);
    Task<ErrorOr<List<Player>>> ListPlayersAsync();
    Task<ErrorOr<Deleted>> DeletePlayer(Player game);

}
