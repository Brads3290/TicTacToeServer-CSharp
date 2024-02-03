using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Games.DTO;

public class NewGameRequest
{

    [Required]
    public required string PlayerId { get; set; }

}