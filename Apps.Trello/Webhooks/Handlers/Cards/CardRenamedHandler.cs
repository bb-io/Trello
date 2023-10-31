using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardRenamedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_renamed_card";
    
    public CardRenamedHandler(InvocationContext invocationContext): base(invocationContext) { }
}