using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCommentAddedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_comment_on_card";
}