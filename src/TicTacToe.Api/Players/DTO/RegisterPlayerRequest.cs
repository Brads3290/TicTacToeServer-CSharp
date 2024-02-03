using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Players.DTO;

public class RegisterPlayerRequest {

    [Required]
    public required string Nickname { get; set; }

}