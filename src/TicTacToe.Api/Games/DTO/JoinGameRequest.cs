using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Games.DTO;

public class JoinGameRequest {

    [Required]
    public required string PlayerId { get; set; }

}