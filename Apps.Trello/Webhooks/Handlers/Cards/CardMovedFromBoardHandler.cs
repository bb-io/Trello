using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedFromBoardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_from_board";
    
    public CardMovedFromBoardHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}