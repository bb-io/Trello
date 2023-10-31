using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberAddedToCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_joined_card";
    
    public MemberAddedToCardHandler(InvocationContext invocationContext): base(invocationContext) { }
}