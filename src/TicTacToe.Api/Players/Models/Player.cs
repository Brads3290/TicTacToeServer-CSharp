namespace TicTacToe.Api.Players.Models;

public class Player {

    public string Id { get; set; }
    public string Nickname { get; set; }

    public Player(string id, string nickname) {
        Id = id;
        Nickname = nickname;
    }

}