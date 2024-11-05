using Apps.Trello.Actions.Base;
using Apps.Trello.Invocables;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Polling.Models;
using Apps.Trello.Polling.Models.Response;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using Manatee.Trello;

namespace Apps.Trello.Polling;

[PollingEventList]
public class CardPollingEvents(InvocationContext invocationContext) : TrelloActions(invocationContext)
{
    [PollingEvent("On cards comments added", Description = "Polling event. Triggered after specified time interval and returns new comments")]
    public async Task<PollingEventResponse<DateMemory, CardsCommentsResponse>> OnCardsCommentsAdded(
        PollingEventRequest<DateMemory> request,
        [PollingEventParameter] BoardCardsFilterRequest filterRequest)
    {
        try
        {
            if (request.Memory is null)
            {
                return new()
                {
                    FlyBird = false,
                    Memory = new()
                    {
                        LastInteractionDate = DateTime.UtcNow
                    }
                };
            }
            
            await WebhookLogger.LogAsync(new
            {
                filterRequest,
                lastInteractionDate = request.Memory.LastInteractionDate
            });

            var result = await GetCards(filterRequest, request.Memory.LastInteractionDate);
            return new()
            {
                FlyBird = result.CardComments.Any(),
                Result = result,
                Memory = new()
                {
                    LastInteractionDate = DateTime.UtcNow
                }
            };
        }
        catch (Exception e)
        {
            await WebhookLogger.LogAsync(e);
            throw;
        }
    }
    
    private async Task<CardsCommentsResponse> GetCards(BoardCardsFilterRequest filterRequest, DateTime lastInteractionDate)
    {
        var board = await GetBoardData(filterRequest.BoardId);
        board.Cards.Limit = filterRequest.Limit ?? 100;
        await board.Cards.Refresh();
        
        await WebhookLogger.LogAsync(new
        {
            cards = board.Cards.Select(c => new { c.Id, c.Name }),
            dtos = board.Cards.Select(c => new CardEntity(c)).ToArray()
        });
        
        var comments = new List<CardCommentResponse>();
        foreach (var card in board.Cards)
        {
            card.Comments.Limit = filterRequest.Limit ?? 100;
            card.Comments.Filter(lastInteractionDate, DateTime.UtcNow);
            await card.Comments.Refresh();
            
            await WebhookLogger.LogAsync(new
            {
                cardId = card.Id,
                comments = card.Comments.Select(c => new { c.Id, c.Data, c.Data.Text }),
                lastInteractionDate
            });
            
            comments.AddRange(card.Comments.Select(c => new CardCommentResponse(c)));
        }
        
        return new()
        {
            CardComments = comments
        };
    }
}