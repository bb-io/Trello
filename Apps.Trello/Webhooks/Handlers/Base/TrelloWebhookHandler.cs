using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Base;

public abstract class TrelloWebhookHandler<T> : BridgeWebhookHandler where T : class, ICanWebhook
{
    protected abstract string Event { get; }
    private T Entity { get; }
    
    private TrelloFactory Client { get; }
    
    protected TrelloWebhookHandler(T entity)
    {
        Client = new();
        Entity = entity;
    }
    
    public override async Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        await base.SubscribeAsync(creds, values);

        await Client.Webhook(Entity, ApplicationConstants.BridgeServiceUrl);
    }

    public override async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        await base.UnsubscribeAsync(creds, values);

        var webhook = await Client.Webhook(Entity, ApplicationConstants.BridgeServiceUrl);
        await webhook.Delete();
    }
    
    protected override Task<(BridgeRequest, BridgeCredentials)> GetBridgeServiceInputs(
        Dictionary<string, string> values, IEnumerable<AuthenticationCredentialsProvider> creds)
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