using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class CardRequest
{
    [Display("Card ID")]
    public string CardId { get; set; }
}