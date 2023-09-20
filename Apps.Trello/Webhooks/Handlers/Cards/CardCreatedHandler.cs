using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCreatedHandler : TrelloWebhookHandler<Board>
{
    protected override string Event => "createCard";
    
    public CardCreatedHandler([WebhookParameter] BoardRequest input) : base(new(input.BoardId))
    {
    }
}