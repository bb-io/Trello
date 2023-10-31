using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedFromBoardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_from_board";
    
    public CardMovedFromBoardHandler(InvocationContext invocationContext): base(invocationContext) { }
}