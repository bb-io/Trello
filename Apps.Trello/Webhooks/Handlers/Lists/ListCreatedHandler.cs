using Apps.Trello.Webhooks.Handlers.Base;

namespace Apps.Trello.Webhooks.Handlers.Lists;

public class ListCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_added_list_to_board";
}