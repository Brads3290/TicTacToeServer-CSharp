using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace TicTacToe.Api.Common;

public class TicTacToeControllerBase : ControllerBase {

    [NonAction]
    public IActionResult ErrorResult(Error err) {
        var response = ErrorResponse.From(err);

        return err.Code switch {
            "GameService.PlayerNotFound" => NotFound(response),
            "GameService.NotFound" => NotFound(response),
            "GameService.GameFull" => BadRequest(response),
            "GameService.GameNotJoinable" => BadRequest(response),
            _ => StatusCode(500, err)
        };
    }

}