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
        GameStatus status,
        GameResult? result,
        string? winner = null
    ) {
        Id = id;
        PlayerToMove = playerToMove;
        Board = board;
        Status = status;
        Result = result;
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
        status: GameStatus.Waiting,
        result: null,
        winner: null);

}