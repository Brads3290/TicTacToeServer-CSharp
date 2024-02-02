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
    public async Task<IActionResult> NewGame()
    {
        var result = await _gameService.StartGameAsync();
        if (result.IsError)
        {
            return ErrorResult(result.FirstError);
        }

        return Ok(result.Value);

    }



}