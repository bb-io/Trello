using Apps.Trello.Webhooks.Handlers.Cards;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.WebhookLists;

[WebhookList]
public class CardWebhooks
{
    [Webhook("On card created", typeof(CardCreatedHandler), Description = "On a new card created")]
    public Task<WebhookResponse<object>> OnCardCreated(WebhookRequest request)
    {
        throw new NotImplementedException();
    }
    
    [Webhook("On card updated", typeof(CardUpdatedHandler), Description = "On a specific card updated")]
    public Task<WebhookResponse<object>> OnCardUpdated(WebhookRequest request)
    {
        throw new NotImplementedException();
    }
    
    [Webhook("On card comment added", typeof(CardCommentAddedHandler), Description = "On a specific card comment added")]
    public Task<WebhookResponse<object>> OnCardCommentAdded(WebhookRequest request)
    {
        throw new NotImplementedException();
    }
}