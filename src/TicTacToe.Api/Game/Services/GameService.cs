using System.ComponentModel.DataAnnotations;
using ErrorOr;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using TicTacToe.Api.Common;
using TicTacToe.Api.Game.Interfaces;
using TicTacToe.Api.Game.Models;
using TicTacToe.Api.Players.Interfaces;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Game.Services;

public class GameService : IGameService {

    private readonly IGameRepository _gameRepository;
    private readonly IPlayerRepository _playerRepository;

    public GameService(IGameRepository gameRepository, IPlayerRepository playerRepository) {
        _gameRepository = gameRepository;
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<GameState>> StartGameAsync(string playerId) {
        var player = await _playerRepository.GetPlayerAsync(playerId);
        if (player is null) {
            return GameServiceErrors.PlayerNotFound;
        }

        var gameState = GameState.Empty();
        gameState.Players.Add(GamePlayerInfo.From(player, Utilities.RandomSymbol()));

        await _gameRepository.SaveGameAsync(gameState);
        return gameState;
    }

    public async Task<ErrorOr<List<GameState>>> ListOpenGamesAsync() {
        var games = await _gameRepository.ListGameStatesAsync();

        return games
            .Where(x => x.Status != GameStatus.Finished)
            .ToList();
    }

    public async Task<ErrorOr<GameState>> MakeMoveAsync(string gameId, string playerId, int row, int col) {
        var player = await _playerRepository.GetPlayerAsync(playerId);
        if (player is null) {
            return GameServiceErrors.PlayerNotFound;
        }

        var game = await _gameRepository.GetGameAsync(gameId);
        if (game is null) {
            return GameServiceErrors.GameNotFound;
        }
        
        var result = MakeMoveForPlayer(player, game, row, col);
        if (result.IsError) {
            return result.Errors;
        }

        await _gameRepository.SaveGameAsync(game);
        return game;
    }

    public async Task<ErrorOr<GameState>> GetGameStateAsync(string id) {
        var game = await _gameRepository.GetGameAsync(id);
        if (game is null) {
            return GameServiceErrors.GameNotFound;
        }

        return game;
    }

    public async Task<ErrorOr<GameState>> ResignGameAsync(string gameId, string playerId) {
        var player = await _playerRepository.GetPlayerAsync(playerId);
        if (player is null) {
            return GameServiceErrors.PlayerNotFound;
        }

        var game = await _gameRepository.GetGameAsync(gameId);
        if (game is null) {
            return GameServiceErrors.GameNotFound;
        }
        
        var result = ResignPlayerFromGame(player, game);
        if (result.IsError) {
            return result.Errors;
        }

        await _gameRepository.SaveGameAsync(game);
        return game;
    }

    public async Task<ErrorOr<GameState>> JoinGameAsync(string gameId, string playerId) {
        var player = await _playerRepository.GetPlayerAsync(playerId);
        if (player is null) {
            return GameServiceErrors.PlayerNotFound;
        }

        var game = await _gameRepository.GetGameAsync(gameId);
        if (game is null) {
            return GameServiceErrors.GameNotFound;
        }

        var result = game.JoinGame(player);
        if (result.IsError) {
            return result.Errors;
        }

        return game;
    }

    private static ErrorOr<Success> MakeMoveForPlayer(Player player, GameState game, int row, int col) {
        var result = game.PlayerMove(row, col, player.Id);
        if (result.IsError) {
            return result.Errors;
        }
        
        // Check for win or draw
        game.UpdateState();
        return new Success();
    }

    private static ErrorOr<Success> ResignPlayerFromGame(Player player, GameState game) {
        var gamePlayer = game.Players.FirstOrDefault(x => x.PlayerId == player.Id);
        if (gamePlayer is null) {
            return GameServiceErrors.PlayerNotInGame;
        }

        var otherPlayer = game.Players.Single(x => x.PlayerId != player.Id);
        game.SetWinner(otherPlayer.PlayerId);

        return new Success();
    }

}