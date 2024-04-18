using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Responses.Board;

public class CreateBoardResponse
{
    [Display("Board ID")]
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    [Display("URL")]
    public string Url { get; set; }

    [Display("Creation date")] public DateTime CreationDate { get; set; }
    
    public CreateBoardResponse(IBoard board)
    {
        Id = board.Id;
        Name = board.Name;
        Description = board.Description;
        Url = board.Url;
        CreationDate = board.CreationDate;
    }
}