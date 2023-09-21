using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardRenamedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_renamed_card";
    
    public CardRenamedHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}