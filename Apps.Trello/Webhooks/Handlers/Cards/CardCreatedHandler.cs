using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_create_card";
    
    public CardCreatedHandler(InvocationContext invocationContext): base(invocationContext) { }
}