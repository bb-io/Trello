using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardRenamedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_renamed_card";
}