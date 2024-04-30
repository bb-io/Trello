using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Board;

public class UpdateBoardRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }

    [Display("Is closed")] public bool? IsClosed { get; set; }

    [Display("Is subscribed")] public bool? IsSubscribed { get; set; }
}