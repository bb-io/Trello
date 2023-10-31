using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Lists;

public class ListCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_added_list_to_board";
    
    public ListCreatedHandler(InvocationContext invocationContext): base(invocationContext) { }
}