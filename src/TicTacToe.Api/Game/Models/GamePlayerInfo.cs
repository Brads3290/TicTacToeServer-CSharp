namespace TicTacToe.Api.Game.Models;

public class GamePlayerInfo {

    public string PlayerId { get; set; }
    public string Symbol { get; set; }

    public GamePlayerInfo(string playerId, string symbol) {
        PlayerId = playerId;
        Symbol = symbol;
    }

}