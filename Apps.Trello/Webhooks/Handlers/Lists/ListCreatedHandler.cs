using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Lists;

public class ListCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_added_list_to_board";
    
    public ListCreatedHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}