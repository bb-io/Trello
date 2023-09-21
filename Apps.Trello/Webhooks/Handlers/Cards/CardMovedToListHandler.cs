using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedToListHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_from_list_to_list";
    
    public CardMovedToListHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}