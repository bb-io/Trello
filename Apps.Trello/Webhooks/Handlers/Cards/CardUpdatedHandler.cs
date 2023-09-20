using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardUpdatedHandler : TrelloWebhookHandler<Board>
{
    protected override string Event => "updateCard";
    
    public CardUpdatedHandler([WebhookParameter] BoardRequest input) : base(new(input.BoardId))
    {
    }
}