using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Responses.Board;
using Apps.Trello.Polling.Models;
using Apps.Trello.Polling.Models.Request;
using Apps.Trello.Polling.Models.Response;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Apps.Trello.Polling;

[PollingEventList]
public class CardPollingEvents(InvocationContext invocationContext) : TrelloActions(invocationContext)
{
    [PollingEvent("On cards comments added", Description = "Polling event. Triggered after specified time interval and returns new comments")]
    public async Task<PollingEventResponse<DateMemory, CardsCommentsResponse>> OnCardsCommentsAdded(
        PollingEventRequest<DateMemory> request,
        [PollingEventParameter] PollingBoardCardsFilterRequest filterRequest,
        [PollingEventParameter] CardsCommentAddedFilterRequest commentFilterRequest)
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

        var boardIds = new List<string>();
        if (filterRequest.BoardIds != null)
        {
            boardIds.AddRange(filterRequest.BoardIds);
        }
        else
        {
            var boards = await GetBoardsAsync();
            boardIds.AddRange(boards.Boards.Select(b => b.Id));
        }
        
        var response = new CardsCommentsResponse();

        foreach (var boardId in boardIds)
        {
            var result = await GetCardsAsync(new()
            {
                Limit = filterRequest.Limit,
                BoardId = boardId
            }, commentFilterRequest, request.Memory.LastInteractionDate);
            
            response.CardComments.AddRange(result.CardComments);
        }
        
        return new()
        {
            FlyBird = response.CardComments.Any(),
            Result = response,
            Memory = new()
            {
                LastInteractionDate = DateTime.UtcNow
            }
        };
    }
    
    private async Task<CardsCommentsResponse> GetCardsAsync(BoardCardsFilterRequest filterRequest, 
        CardsCommentAddedFilterRequest commentFilterRequest, 
        DateTime lastInteractionDate)
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
            
            comments.AddRange(card.Comments.Select(c => new CardCommentResponse(c) { BoardId = board.Id }));
        }

        if (!string.IsNullOrEmpty(commentFilterRequest.ContainsText))
        {
            comments = comments
                .Where(c => c.Text.Contains(commentFilterRequest.ContainsText, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        
        return new()
        {
            CardComments = comments
        };
    }

    private async Task<ListBoardsResponse> GetBoardsAsync()
    {
        var me = await Client.Me();
        await me.Boards.Refresh();

        var boards = me.Boards.Select(x => new BoardEntity(x)).ToArray();
        return new(boards);
    }     
}