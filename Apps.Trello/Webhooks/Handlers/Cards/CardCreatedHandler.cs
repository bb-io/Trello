using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_create_card";
}