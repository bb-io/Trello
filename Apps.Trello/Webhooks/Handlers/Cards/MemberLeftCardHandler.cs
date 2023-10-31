using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberLeftCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_left_card";
    
    public MemberLeftCardHandler(InvocationContext invocationContext): base(invocationContext) { }
}