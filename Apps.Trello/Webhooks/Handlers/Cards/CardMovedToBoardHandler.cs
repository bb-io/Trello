using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedToBoardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_to_board";
    
    public CardMovedToBoardHandler(InvocationContext invocationContext): base(invocationContext) { }
}