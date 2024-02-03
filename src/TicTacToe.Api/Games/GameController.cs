using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Common;
using TicTacToe.Api.Games.DTO;
using TicTacToe.Api.Games.Interfaces;

namespace TicTacToe.Api.Games;

[ApiController]
[Route("games")]
public class GameController : TicTacToeControllerBase {

    private readonly IGameService _gameService;

    public GameController(IGameService gameService) {
        _gameService = gameService;
    }

    [Route("new")]
    [HttpPost]
    public async Task<IActionResult> NewGame([FromBody] NewGameRequest request) {
        var result = await _gameService.StartGameAsync(request.PlayerId);
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("open")]
    [HttpGet]
    public async Task<IActionResult> OpenGames() {
        var result = await _gameService.ListOpenGamesAsync();
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}")]
    [HttpGet]
    public async Task<IActionResult> GetGameState(string gameId) {
        var result = await _gameService.GetGameStateAsync(gameId);
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}/join")]
    [HttpPost]
    public async Task<IActionResult> JoinGame(string gameId, [FromBody] JoinGameRequest request) {
        var result = await _gameService.JoinGameAsync(gameId, request.PlayerId);
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}/resign")]
    [HttpPost]
    public async Task<IActionResult> ResignGame(string gameId, [FromBody] ResignGameRequest request) {
        var result = await _gameService.ResignGameAsync(gameId, request.PlayerId);
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}/move")]
    [HttpPost]
    public async Task<IActionResult> MakeMove(string gameId, [FromBody] MakeMoveRequest request) {
        var result = await _gameService.MakeMoveAsync(gameId, request.PlayerId, request.Row, request.Column);
        if (result.IsError) {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

}