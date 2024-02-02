using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Game.Models;

public class GamePlayerInfo {

    public required string PlayerId { get; set; }
    public required string Nickname { get; set; } // TODO: Update the spec in the pet project GitHub repo
    public required string Symbol { get; set; }

    public static GamePlayerInfo From(Player player, string symbol) => new() {
        PlayerId = player.Id,
        Nickname = player.Nickname,
        Symbol = symbol,
    };

}