using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Game.Interfaces;

namespace TicTacToe.Api.Game;

[ApiController]
[Route("game")]
public class GameController : ControllerBase {

    private readonly IGameService _gameService;
    
    public GameController(IGameService gameService) {
        _gameService = gameService;
    }

    [Route("new")]
    public async Task NewGame() {
        _gameService.
    }

}