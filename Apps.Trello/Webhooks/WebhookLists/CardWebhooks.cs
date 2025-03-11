using System.Net;
using Apps.Trello.Webhooks.Handlers.Base;
using Apps.Trello.Webhooks.Handlers.Cards;
using Apps.Trello.Webhooks.Models;
using Apps.Trello.Webhooks.Models.Response;
using Apps.Trello.Webhooks.Models.Response.Card;
using Apps.Trello.Webhooks.WebhookLists.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.WebhookLists;

[WebhookList]
public class CardWebhooks : TrelloWebhookList
{
    [Webhook("On card created", typeof(CardCreatedHandler), Description = "On a new card created")]
    public Task<WebhookResponse<CardWebhookResponse>> OnCardCreated(WebhookRequest request)
        => HandleWebhook<CardWebhookResponse>(request);

    [Webhook("On card renamed", typeof(CardRenamedHandler), Description = "On a specific card renamed")]
    public async Task<WebhookResponse<CardRenamedWebhookResponse>> OnCardRenamed(
            WebhookRequest request,
            [WebhookParameter] CardOptionFilter filter)
    {
        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<TrelloWebhookResponse<CardRenamedWebhookResponse>>(payload)
                   ?? throw new Exception("Cannot process webhook data");

        if (!string.IsNullOrEmpty(filter.CardId) && data.Action.Data.Card.CardId != filter.CardId)
        {
            return new WebhookResponse<CardRenamedWebhookResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        return await HandleWebhook<CardRenamedWebhookResponse>(request);
    }

    [Webhook("On card moved to list", typeof(CardMovedToListHandler), Description = "On a specific card moved to another list")]
    public async Task<WebhookResponse<CardMovedToListWebhookResponse>> OnCardMovedToList(WebhookRequest request, [WebhookParameter] CardOptionFilter filter)
    {
        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<TrelloWebhookResponse<CardMovedToListWebhookResponse>>(payload)
              ?? throw new Exception("Cannot process webhook data");

        if (!string.IsNullOrEmpty(filter.CardId) && data.Action.Data.Card.CardId != filter.CardId)
        {
            return new WebhookResponse<CardMovedToListWebhookResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        if (!string.IsNullOrEmpty(filter.OldListId) && data.Action.Data.ListBefore.ListId != filter.OldListId)
        {
            return new WebhookResponse<CardMovedToListWebhookResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        if (!string.IsNullOrEmpty(filter.NewListId) && data.Action.Data.ListAfter.ListId != filter.NewListId)
        {
            return new WebhookResponse<CardMovedToListWebhookResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }
        return await HandleWebhook<CardMovedToListWebhookResponse>(request);

    }

    [Webhook("On card comment added", typeof(CardCommentAddedHandler), Description = "On a specific card comment added")]
    public async Task<WebhookResponse<CardCommentAddedWebhookResponse>> OnCardCommentAdded(
             WebhookRequest request,
             [WebhookParameter] CardOptionFilter filter)
    {
        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<TrelloWebhookResponse<CardCommentAddedWebhookResponse>>(payload)
                   ?? throw new Exception("Cannot process webhook data");

        if (!string.IsNullOrEmpty(filter.CardId) && data.Action.Data.Card.CardId != filter.CardId)
        {
            return new WebhookResponse<CardCommentAddedWebhookResponse>
            {
                HttpResponseMessage = new HttpResponseMessage(HttpStatusCode.OK),
                ReceivedWebhookRequestType = WebhookRequestType.Preflight
            };
        }

        return await HandleWebhook<CardCommentAddedWebhookResponse>(request);
    }

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