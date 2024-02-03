using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Players.DTO;

public class RegisterPlayerResponse {

    
    [Required]
    public required string Id { get; set; }
    
    [Required]
    public required string Nickname { get; set; }

}