using ErrorOr;

namespace TicTacToe.Api.Common;

class ErrorResponse
{
    public ErrorDetails error { get; set; }

    public ErrorResponse(string code, string message)
    {
        this.error = new ErrorDetails(code, message);
        // This is one way to do it if you don't like to have YET ANOTHER CONSTRUCTOR.
        // {
        //     code = code,
        //     message = message
        // };
    }

    public static ErrorResponse From(Error err)
    {
        return new ErrorResponse(err.Code, err.Description);
    }
}

class ErrorDetails
{
    public string code { get; set; }
    public string message { get; set; }
    public ErrorDetails(string code, string message)
    {
        this.code = code;
        this.message = message;
    }
}