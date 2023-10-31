using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCommentAddedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_comment_on_card";
    
    public CardCommentAddedHandler(InvocationContext invocationContext): base(invocationContext) { }
}