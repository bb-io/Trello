using Apps.Trello.Webhooks.Handlers.Lists;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.WebhookLists;

[WebhookList]
public class ListWebhooks
{
    [Webhook("On list created", typeof(ListCreatedHandler), Description = "On a new list created")]
    public Task<WebhookResponse<object>> OnListCreated(WebhookRequest request)
    {
        throw new NotImplementedException();
    }
}