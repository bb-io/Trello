using Apps.Trello.Extensions;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Base;

public abstract class TrelloWebhookHandler : BaseInvocable, IWebhookEventHandler
{
    protected abstract string Event { get; }

    private TrelloFactory Client { get; }
    private string BridgeServiceUrl => $"{InvocationContext.UriInfo.BridgeServiceUrl}/webhooks/trello";

    protected TrelloWebhookHandler(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }

    public async Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var auth = creds.GetAuth();
        var me = await Client.Me(auth);

        var (webhookData, bridgeCreds) = await GetBridgeServiceInputs(values, me.Id);
        await BridgeService.Subscribe(webhookData, bridgeCreds);

        await Client.Webhook(me, BridgeServiceUrl, null, auth);
    }

    public async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> creds,
        Dictionary<string, string> values)
    {
        var auth = creds.GetAuth();
        var me = await Client.Me(auth);

        var (webhookData, bridgeCreds) = await GetBridgeServiceInputs(values, me.Id);
        await BridgeService.Unsubscribe(webhookData, bridgeCreds);
    }

    private Task<(BridgeRequest, BridgeCredentials)> GetBridgeServiceInputs(Dictionary<string, string> values,
        string meId)
    {
        var webhookData = new BridgeRequest()
        {
            Url = values["payloadUrl"],
            Event = Event,
            Id = meId
        };

        var bridgeCreds = new BridgeCredentials()
        {
            ServiceUrl = BridgeServiceUrl,
            Token = ApplicationConstants.BlackbirdToken
        };

        return Task.FromResult((webhookData, bridgeCreds));
    }
}