namespace Apps.Trello.Webhooks.Models.Response;

public class TrelloWebhookResponse<T>
{
    public TrelloAction<T> Action { get; set; }
}