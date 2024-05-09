using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class CardFilterRequest
{
    [Display("Limit", Description = "Limit the number of cards to return. Default is 100.")]
    public int? Limit { get; set; }
}