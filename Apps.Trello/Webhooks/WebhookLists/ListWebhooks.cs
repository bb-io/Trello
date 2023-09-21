using Apps.Trello.Webhooks.Handlers.Lists;
using Apps.Trello.Webhooks.Models.Response.List;
using Apps.Trello.Webhooks.WebhookLists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.WebhookLists;

[WebhookList]
public class ListWebhooks : TrelloWebhookList
{
    [Webhook("On list created", typeof(ListCreatedHandler), Description = "On a new list created")]
    public Task<WebhookResponse<ListWebhookResponse>> OnListCreated(WebhookRequest request)
        => HandleWebhook<ListWebhookResponse>(request);
}