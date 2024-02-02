using TicTacToe.Api.Common;

namespace TicTacToe.Api.Players.Models;

public class Player {

    public string Id { get; set; }
    public string Nickname { get; set; }

    public Player(string nickname, string? id = null) {
        Id = id ?? Utilities.NewId();
        Nickname = nickname;
    }

}