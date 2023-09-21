using Apps.Trello.Webhooks.Models.Response;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.WebhookLists.Base;

public abstract class TrelloWebhookList
{
    protected Task<WebhookResponse<T>> HandleWebhook<T>(WebhookRequest request) where T : class
    {
        var payload = request.Body.ToString();

        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<TrelloWebhookResponse<T>>(payload) ??
                   throw new("Cannot process webhook data");

        return Task.FromResult(new WebhookResponse<T>()
        {
            Result = data.Action.Data
        });
    }
}