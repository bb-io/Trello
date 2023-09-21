using Apps.Trello.Webhooks.Models.Payloads;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardWebhookResponse
{
    public CardPayload Card { get; set; }
    public ListPayload List { get; set; }
    public BoardPayload Board { get; set; }
}