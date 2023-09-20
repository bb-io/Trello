using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Manatee.Trello;

namespace Apps.Trello.Webhooks.Handlers.Lists;

public class ListCreatedHandler : TrelloWebhookHandler<Board>
{
    protected override string Event => "createList";
    
    public ListCreatedHandler([WebhookParameter] BoardRequest input) : base(new(input.BoardId))
    {
    }
}