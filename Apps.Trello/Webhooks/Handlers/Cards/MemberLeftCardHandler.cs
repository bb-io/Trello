using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberLeftCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_left_card";
}