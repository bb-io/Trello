using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class MemberAddedToCardHandler : TrelloWebhookHandler
{
    protected override string Event => "action_member_joined_card";
    
    public MemberAddedToCardHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}