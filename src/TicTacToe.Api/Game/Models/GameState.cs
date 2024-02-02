using System.Diagnostics;
using TicTacToe.Api.Common;

namespace TicTacToe.Api.Game.Models;

public class GameState {

    public string Id { get; set; }
    public string? PlayerToMove { get; set; }
    public string[][] Board { get; set; }
    public List<GamePlayerInfo> Players { get; set; }
    public GameStatus Status { get; set; }
    public GameResult? Result { get; set; }
    public string? Winner { get; set; }

    public GameState(
        string id,
        string? playerToMove,
        string[][] board,
        List<GamePlayerInfo> players,
        GameStatus status,
        GameResult? result,
        string? winner = null
    ) {
        Id = id;
        PlayerToMove = playerToMove;
        Board = board;
        Status = status;
        Result = result;
        Players = players;
        Winner = winner;
    }

    public static GameState Empty() => new(
        id: Utilities.NewId(),
        playerToMove: null,
        board: new string[][] {
            new string[] { "", "", "" },
            new string[] { "", "", "" },
            new string[] { "", "", "" },
        },
        players: new(),
        status: GameStatus.Waiting,
        result: null,
        winner: null);

    public void SetWinner(string playerId) {
        Result = GameResult.Win;
        Status = GameStatus.Finished;
        Winner = playerId;
        PlayerToMove = null;
    }

}