using ErrorOr;
using TicTacToe.Api.Players.Interfaces;
using TicTacToe.Api.Players.Models;

namespace TicTacToe.Api.Players.Services;

public class PlayerService : IPlayerService {

    private readonly IPlayerRepository _playerRepository;
    
    public PlayerService(IPlayerRepository playerRepository) {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<Player>> CreatePlayerAsync(string nickname) {
        var player = await _playerRepository.GetPlayerByNicknameAsync(nickname);
        if (player is not null) {
            return PlayerServiceErrors.NicknameTaken;
        }

        player = new(nickname);
        await _playerRepository.SavePlayerAsync(player);
        return player;
    }
    
}