using Apps.Trello.Webhooks.Models.Payloads;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardMovedToBoardWebhookResponse : CardWebhookResponse
{
    [Display("Source board")]
    public IdPayload BoardSource { get; set; }

}