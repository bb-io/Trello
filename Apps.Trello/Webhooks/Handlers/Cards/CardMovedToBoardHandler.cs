using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedToBoardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_to_board";
    
    public CardMovedToBoardHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}