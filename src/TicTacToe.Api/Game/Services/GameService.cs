using ErrorOr;
using TicTacToe.Api.Game.Interfaces;
using TicTacToe.Api.Game.Models;

namespace TicTacToe.Api.Game.Services;

public class GameService : IGameService {

    private readonly IGameRepository _gameRepository;
    
    public GameService(IGameRepository gameRepository) {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<GameState>> StartGameAsync() {
        
    }

    public async Task<ErrorOr<List<GameState>>> ListOpenGamesAsync() {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<GameState>> GetGameStateAsync() {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<GameState>> ResignGameAsync() {
        throw new NotImplementedException();
    }

}