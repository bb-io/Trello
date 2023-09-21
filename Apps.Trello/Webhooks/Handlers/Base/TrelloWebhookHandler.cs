using Apps.Trello.Extensions;
using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Base;

public abstract class TrelloWebhookHandler : IWebhookEventHandler
{
    protected abstract string Event { get; }

    private ICanWebhook Entity { get; }
    private TrelloFactory Client { get; }

    protected TrelloWebhookHandler([WebhookParameter] BoardRequest input)
    {
        Client = new();
        Entity = new Board(input.BoardId);
    }

    public async Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var (webhookData, bridgeCreds) = await GetBridgeServiceInputs(values);
        await BridgeService.Subscribe(webhookData, bridgeCreds);

        await Client.Webhook(Entity, ApplicationConstants.BridgeServiceUrl, null, creds.GetAuth());
    }

    public async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var (webhookData, bridgeCreds) = await GetBridgeServiceInputs(values);
        await BridgeService.Unsubscribe(webhookData, bridgeCreds);
    }

    private Task<(BridgeRequest, BridgeCredentials)> GetBridgeServiceInputs(
        Dictionary<string, string> values)
    {
        var webhookData = new BridgeRequest()
        {
            Url = values["payloadUrl"],
            Event = Event,
            Id = Entity.Id
        };

        var bridgeCreds = new BridgeCredentials()
        {
            ServiceUrl = ApplicationConstants.BridgeServiceUrl,
            Token = ApplicationConstants.BlackbirdToken
        };

        return Task.FromResult((webhookData, bridgeCreds));
    }
}