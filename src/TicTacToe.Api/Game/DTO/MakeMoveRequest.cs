public class MakeMoveRequest
{
    public required string PlayerId { get; set; }
    public required int Row { get; set; }
    public required int Column { get; set; }
}