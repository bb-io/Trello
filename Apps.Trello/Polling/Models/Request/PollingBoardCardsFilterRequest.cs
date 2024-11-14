using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Polling.Models.Request;

public class PollingBoardCardsFilterRequest : BoardsOptionalRequest
{
    [Display("Limit", Description = "Limit the number of cards to return. Default is 100.")]
    public int? Limit { get; set; }
}