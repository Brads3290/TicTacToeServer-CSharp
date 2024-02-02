using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Game.Interfaces;
using ErrorOr;


namespace TicTacToe.Api.Game;

[ApiController]
[Route("games")]
public class GameController : ControllerBase {

    private readonly IGameService _gameService;

    public IActionResult ErrorResult(Error err)
    {
        var response = ErrorResponse.From(err);

        return err.Code switch
        {
            "GameService.PlayerNotFound" => NotFound(response),
            "GameService.NotFound" => NotFound(response),
            "GameService.GameFull" => BadRequest(response),
            "GameService.GameNotJoinable" => BadRequest(response),
            _ => StatusCode(500, err)
        };
    }

    public GameController(IGameService gameService) {
        _gameService = gameService;
    }

    [Route("new")]
    public async Task<IActionResult> NewGame([FromBody] NewGameRequest request)
    {
        var result = await _gameService.StartGameAsync(request.PlayerId);
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);

    }

    [Route("open")]
    public async Task<IActionResult> OpenGames()
    {
        var result = await _gameService.ListOpenGamesAsync();
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}")]
    public async Task<IActionResult> GetGameState(string gameId)
    {
        var result = await _gameService.GetGameStateAsync(gameId);
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }
    [Route("{gameId}/join")]
    public async Task<IActionResult> JoinGame(string gameId, [FromBody] JoinGameRequest request)
    {
        var result = await _gameService.JoinGameAsync(gameId, request.PlayerId);
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);

    }

    [Route("{gameId}/resign")]
    public async Task<IActionResult> ResignGame(string gameId, [FromBody] ResignGameRequest request)
    {
        var result = await _gameService.ResignGameAsync(gameId, request.PlayerId);
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }

    [Route("{gameId}/move")]
    public async Task<IActionResult> MakeMove(string gameId, [FromBody] MakeMoveRequest request)
    {
        var result = await _gameService.MakeMoveAsync(gameId, request.PlayerId, request.Row, request.Column);
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);
    }


}