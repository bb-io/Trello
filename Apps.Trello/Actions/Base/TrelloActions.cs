using Apps.Trello.Invocables;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.Actions.Base;

public class TrelloActions(InvocationContext invocationContext) : TrelloInvocable(invocationContext)
{    
    protected async Task<Board> GetBoardData(string boardId)
    {
        var board = new Board(boardId);
        await board.Refresh();
        
        return board;
    }
}