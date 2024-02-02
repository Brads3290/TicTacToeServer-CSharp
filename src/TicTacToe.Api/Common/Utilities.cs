namespace TicTacToe.Api.Common;

public static class Utilities {

    private static readonly Random Rand = new();

    public static string NewId() {
        var guid = Guid.NewGuid();
        var base64 = Convert.ToBase64String(guid.ToByteArray());
        return base64.Replace("=", "")
            .Replace("/", "")
            .Replace("+", "");
    }

    public static string RandomSymbol() {
        return Rand.Next(0, 2) == 0
            ? "X"
            : "O";
    }

}