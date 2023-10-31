using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedToListHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_from_list_to_list";
    
    public CardMovedToListHandler(InvocationContext invocationContext): base(invocationContext) { }
}