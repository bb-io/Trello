using Apps.Trello.Webhooks.Models.Payloads;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardMovedToListWebhookResponse
{
    public CardPayload Card { get; set; }
    public BoardPayload Board { get; set; }
    
    [Display("Old list")]
    public ListPayload ListBefore { get; set; }
    
    [Display("New list")]
    public ListPayload ListAfter { get; set; }
}