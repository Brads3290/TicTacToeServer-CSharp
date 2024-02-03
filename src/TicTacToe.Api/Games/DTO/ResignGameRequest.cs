using System.ComponentModel.DataAnnotations;

namespace TicTacToe.Api.Games.DTO;

public class ResignGameRequest
{

    [Required]
    public required string PlayerId { get; set; }

}