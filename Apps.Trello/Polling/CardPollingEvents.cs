using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Polling.Models;
using Apps.Trello.Polling.Models.Response;
using Blackbird.Applications.Sdk.Common.Polling;
using Manatee.Trello;

namespace Apps.Trello.Polling;

[PollingEventList]
public class CardPollingEvents
{
    [PollingEvent("On cards comments added", Description = "Polling event. Triggered after specified time interval and returns new comments")]
    public async Task<PollingEventResponse<DateMemory, CardsCommentsResponse>> OnCardsCommentsAdded(
        [PollingEventParameter] BoardCardsFilterRequest filterRequest,
        PollingEventRequest<DateMemory> request)
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
    
    private async Task<CardsCommentsResponse> GetCards(BoardCardsFilterRequest filterRequest, DateTime lastInteractionDate)
    {
        var board = await GetBoardData(filterRequest.BoardId);
        board.Cards.Limit = filterRequest.Limit ?? 100;
        await board.Cards.Refresh();
        
        var comments = new List<CardCommentResponse>();
        foreach (var card in board.Cards)
        {
            card.Comments.Limit = filterRequest.Limit ?? 100;
            card.Comments.Filter(lastInteractionDate, DateTime.UtcNow);
            await card.Comments.Refresh();
            
            comments.AddRange(card.Comments.Select(c => new CardCommentResponse(c)));
        }
        
        return new()
        {
            CardComments = comments
        };
    }
    
    private async Task<Board> GetBoardData(string boardId)
    {
        var board = new Board(boardId);
        await board.Refresh();
        
        return board;
    }
}