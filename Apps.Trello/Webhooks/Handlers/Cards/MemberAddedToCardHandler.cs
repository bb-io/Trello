using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberAddedToCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_joined_card";
}