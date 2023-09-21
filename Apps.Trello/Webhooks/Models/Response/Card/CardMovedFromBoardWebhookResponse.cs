using Apps.Trello.Webhooks.Models.Payloads;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardMovedFromBoardWebhookResponse : CardWebhookResponse
{
    public UserPayload Member { get; set; }
    
    [Display("Target board")]
    public IdPayload BoardTarget { get; set; }

}