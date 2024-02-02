using ErrorOr;
using TicTacToe.Api.Common;
using TicTacToe.Api.Game.Interfaces;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Game.Models;

public class Game {

    public const string SymbolX = "X";
    public const string SymbolO = "O";
    
    public string Id { get; set; }
    public string? PlayerToMove { get; set; }
    public string[][] Board { get; set; }
    public List<GamePlayerInfo> Players { get; set; }
    public GameStatus Status { get; set; }
    public GameResult? Result { get; set; }
    public string? Winner { get; set; }

    public Game(
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

    public static Game Empty() => new(
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

    public ErrorOr<Success> JoinGame(Player player) {
        if (Players.Any(x => x.PlayerId == player.Id)) {
            return GameServiceErrors.PlayerAlreadyInGame;
        }

        if (Players.Count >= 2) {
            return GameServiceErrors.GameFull;
        }

        var usedSymbols = Players.Select(x => x.Symbol).ToList();
        string symbolToUse;
        if (usedSymbols.Count == 0) {
            symbolToUse = Utilities.RandomSymbol();
        } else if (usedSymbols[0] == SymbolX) {
            symbolToUse = SymbolO;
        } else {
            symbolToUse = SymbolX;
        }
        
        var gamePlayer = GamePlayerInfo.From(player, symbolToUse);
        Players.Add(gamePlayer);
        return new Success();
    }
    
    public void SetWinner(string playerId) {
        Result = GameResult.Win;
        Status = GameStatus.Finished;
        Winner = playerId;
        PlayerToMove = null;
    }

    public void SetDraw() {
        Result = GameResult.Draw;
        Status = GameStatus.Finished;
        Winner = null;
        PlayerToMove = null;
    }

    public ErrorOr<Success> PlayerMove(int row, int col, string playerId) {
        var player = Players.FirstOrDefault(x => x.PlayerId == playerId);
        if (player is null) {
            return GameServiceErrors.PlayerNotInGame;
        }

        if (Board[row][col] != "") {
            return GameServiceErrors.InvalidMove;
        }

        Board[row][col] = player.Symbol;
        return new Success();
    }

    public void UpdateState() {
        // Checks for win or draw
        foreach (var player in Players) {
            if (SymbolWins(player.Symbol)) {
                SetWinner(player.PlayerId);
                return;
            }
        }
        
        // If all spots are taken and no winner
        if (AllSpotsTaken()) {
            SetDraw();
        }
    }

    private bool SymbolWins(string symbol) {
        var winningCombinations = new[] {
            // Horizontal
            new[] { (0, 0), (0, 1), (0, 2) },
            new[] { (1, 0), (1, 1), (1, 2) },
            new[] { (2, 0), (2, 1), (2, 2) },

            // Vertical
            new[] { (0, 0), (1, 0), (2, 0) },
            new[] { (0, 1), (1, 1), (2, 1) },
            new[] { (0, 2), (1, 2), (2, 2) },

            // Diagonal
            new[] { (0, 0), (1, 1), (2, 2) },
            new[] { (0, 2), (1, 1), (2, 0) },
        };

        foreach (var combination in winningCombinations) {
            if (SymbolInAll(symbol, combination)) {
                return true;
            }
        }

        return false;
    }

    private bool SymbolInAll(string symbol, IEnumerable<(int row, int col)> places) {
        foreach (var place in places) {
            if (Board[place.row][place.col] != symbol) {
                return false;
            }
        }

        return true;
    }

    private bool AllSpotsTaken() => Board
        .SelectMany(x => x)
        .All(x => !String.IsNullOrEmpty(x));

}