using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Models.Requests.List;
using Apps.Trello.Models.Responses.List;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.Actions;

[ActionList]
public class ListActions : TrelloActions
{
    public ListActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get lists", Description = "Get all board lists")]
    public async Task<GetAllListsResponse> GetBoardLists([ActionParameter] BoardRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        await board.Lists.Refresh();

        var lists = board.Lists.Select(l => new ListEntity(l)).ToArray();

        return new(lists);
    }

    [Action("Create list", Description = "Create list on board")]
    public async Task<ListEntity> CreateList([ActionParameter] CreateListRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        var list = await board.Lists.Add(input.ListName, Position.Bottom);
      
        return new(list);
    }
}