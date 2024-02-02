using Microsoft.AspNetCore.Mvc;
using TicTacToe.Api.Players.Interfaces;

namespace TicTacToe.Api.Players;

[ApiController]
public class PlayersController : ControllerBase {

    private readonly IPlayerService _playerService;
    
    public PlayersController(IPlayerService playerService) {
        _playerService = playerService;
    }
    
    
}