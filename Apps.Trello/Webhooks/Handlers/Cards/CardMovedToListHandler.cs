using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardMovedToListHandler : TrelloWebhookHandler
{
    protected override string Event => "action_move_card_from_list_to_list";
}