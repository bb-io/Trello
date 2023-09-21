using Apps.Trello.Webhooks.Models.Payloads;

namespace Apps.Trello.Webhooks.Models.Response.List;

public class ListWebhookResponse
{
    public ListPayload List { get; set; }
    public BoardPayload Board { get; set; }
}