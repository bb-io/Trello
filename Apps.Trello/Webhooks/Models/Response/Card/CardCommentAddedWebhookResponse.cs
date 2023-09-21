using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Response.Card;

public class CardCommentAddedWebhookResponse : CardWebhookResponse
{
    [Display("Comment text")]
    public string Text { get; set; }
}