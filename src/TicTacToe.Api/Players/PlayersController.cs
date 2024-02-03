using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Common;
using TicTacToe.Api.Players.DTO;
using TicTacToe.Api.Players.Interfaces;

namespace TicTacToe.Api.Players;

[ApiController]
[Route("players")]
public class PlayersController : TicTacToeControllerBase {

    private readonly IPlayerService _playerService;

    public PlayersController(IPlayerService playerService) {
        _playerService = playerService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterPlayerRequest request) {
        var playerResult = await _playerService.CreatePlayerAsync(request.Nickname);
        if (playerResult.IsError) {
            return ErrorResult(playerResult.FirstError);
        }

        var player = playerResult.Value;

        return Ok(new RegisterPlayerResponse() {
            Id = player.Id,
            Nickname = player.Nickname,
        });
    }

}