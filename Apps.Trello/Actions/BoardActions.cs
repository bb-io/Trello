using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Models.Responses.Board;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.Actions;

[ActionList]
public class BoardActions : TrelloActions
{
    public BoardActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }
    
    [Action("List boards", Description = "List all user boards")]
    public async Task<ListBoardsResponse> ListBoards()
    {
        var me = await Client.Me();
        await me.Boards.Refresh();

        var boards = me.Boards.Select(x => new BoardEntity(x)).ToArray();
        return new(boards);
    }        
    
    [Action("List starred boards", Description = "List all boards starred by the user")]
    public async Task<ListBoardsResponse> ListStarredBoards()
    {
        var me = await Client.Me();
        await me.StarredBoards.Refresh();

        var refreshTasks = me.StarredBoards.Select(x => x.Board.Refresh());
        await Task.WhenAll(refreshTasks);

        var boards = me.StarredBoards.Select(x => new BoardEntity(x.Board)).ToArray();
        return new(boards);
    }    
    
    [Action("Create board", Description = "Create a new board")]
    public async Task<CreateBoardResponse> CreateBoard([ActionParameter] CreateBoardRequest input)
    {
        var me = await Client.Me();
        var board = await me.Boards.Add(input.Name, input.Description);
        
        return new(board);
    }    
    
    [Action("Get board", Description = "Get board details")]
    public async Task<BoardEntity> GetBoard([ActionParameter] BoardRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        return new(board);
    }    
    
    [Action("Delete board", Description = "Delete specific board")]
    public Task DeleteBoard([ActionParameter] BoardRequest input)
        => new Board(input.BoardId).Delete();
}