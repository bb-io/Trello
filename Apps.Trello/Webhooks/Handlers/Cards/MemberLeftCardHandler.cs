using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberLeftCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_left_card";
    
    public MemberLeftCardHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}