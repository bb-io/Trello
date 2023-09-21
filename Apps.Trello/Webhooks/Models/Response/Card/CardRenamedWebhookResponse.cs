using Apps.Trello.Webhooks.Models.Payloads;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardRenamedWebhookResponse : CardWebhookResponse
{
    [Display("Old card")]
    public SmallCardPayload Old { get; set; }
}