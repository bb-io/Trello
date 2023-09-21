using Apps.Trello.Webhooks.Models.Payloads;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class MemberCardWebhookResponse
{
    public CardPayload Card { get; set; }
    public BoardPayload Board { get; set; }
    public UserPayload Member { get; set; }
}