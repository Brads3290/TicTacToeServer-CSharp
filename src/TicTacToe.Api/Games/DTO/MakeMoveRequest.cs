using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Games.DTO;

public class MakeMoveRequest
{

    [Required]
    public required string PlayerId { get; set; }

    [Required]
    public required int Row { get; set; }

    [Required]
    public required int Column { get; set; }
}