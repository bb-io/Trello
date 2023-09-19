namespace Apps.Trello.Models.Requests.Board;

public class CreateBoardRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
}