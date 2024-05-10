using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class BoardCardsFilterRequest : BoardRequest
{
    [Display("Limit", Description = "Limit the number of cards to return. Default is 100.")]
    public int? Limit { get; set; }
}