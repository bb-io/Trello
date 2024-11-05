using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Polling.Models.Request;

public class CardsCommentAddedFilterRequest
{
    [Display("Message contains text")]
    public string? ContainsText { get; set; }
}