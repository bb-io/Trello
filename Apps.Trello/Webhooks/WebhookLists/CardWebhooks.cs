using Apps.Trello.Webhooks.Handlers.Cards;
using Apps.Trello.Webhooks.Models.Response.Card;
using Apps.Trello.Webhooks.WebhookLists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.WebhookLists;

[WebhookList]
public class CardWebhooks : TrelloWebhookList
{
    [Webhook("On card created", typeof(CardCreatedHandler), Description = "On a new card created")]
    public Task<WebhookResponse<CardWebhookResponse>> OnCardCreated(WebhookRequest request)
        => HandleWebhook<CardWebhookResponse>(request);
    
    [Webhook("On card renamed", typeof(CardRenamedHandler), Description = "On a specific card renamed")]
    public Task<WebhookResponse<CardRenamedWebhookResponse>> OnCardRenamed(WebhookRequest request)
        => HandleWebhook<CardRenamedWebhookResponse>(request);
    
    [Webhook("On card moved to list", typeof(CardMovedToListHandler), Description = "On a specific card moved to another list")]
    public Task<WebhookResponse<CardMovedToListWebhookResponse>> OnCardMovedToList(WebhookRequest request)
        => HandleWebhook<CardMovedToListWebhookResponse>(request);
    
    [Webhook("On card comment added", typeof(CardCommentAddedHandler), Description = "On a specific card comment added")]
    public Task<WebhookResponse<CardCommentAddedWebhookResponse>> OnCardCommentAdded(WebhookRequest request)
        => HandleWebhook<CardCommentAddedWebhookResponse>(request);
    
    [Webhook("On member added to card", typeof(MemberAddedToCardHandler), Description = "On a new member added to the card")]
    public Task<WebhookResponse<MemberCardWebhookResponse>> OnMemberAddedToCard(WebhookRequest request)
        => HandleWebhook<MemberCardWebhookResponse>(request);
    
    [Webhook("On member left card", typeof(MemberLeftCardHandler), Description = "On a member removed from card")]
    public Task<WebhookResponse<MemberCardWebhookResponse>> OnMemberLeftCard(WebhookRequest request)
        => HandleWebhook<MemberCardWebhookResponse>(request);
    
    [Webhook("On card moved from board", typeof(CardMovedFromBoardHandler), Description = "On a specific card moved from the board")]
    public Task<WebhookResponse<CardMovedFromBoardWebhookResponse>> OnCardMovedFromBoard(WebhookRequest request)
        => HandleWebhook<CardMovedFromBoardWebhookResponse>(request);
    
    [Webhook("On card moved to board", typeof(CardMovedToBoardHandler), Description = "On a specific card moved to the board")]
    public Task<WebhookResponse<CardMovedToBoardWebhookResponse>> OnCardMovedToBoard(WebhookRequest request)
        => HandleWebhook<CardMovedToBoardWebhookResponse>(request);
}