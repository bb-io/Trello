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

    [Action("Get list", Description = "Get details of a specific list")]
    public async Task<ListEntity> GetList([ActionParameter] ListRequest input)
    {
        var list = new List(input.ListId);
        await list.Refresh();

        return new(list);
    }

    [Action("Create list", Description = "Create list on board")]
    public async Task<ListEntity> CreateList([ActionParameter] CreateListRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        var list = await board.Lists.Add(input.ListName, Position.Bottom);

        return new(list);
    }

    [Action("Update list", Description = "Update details of a specific list")]
    public Task UpdateList(
        [ActionParameter] ListRequest list,
        [ActionParameter] UpdateListRequest input)
    {
        var updateList = new List(list.ListId)
        {
            Name = input.Name,
            IsArchived = input.IsArchived,
            IsSubscribed = input.IsSubscribed,
            Position = input.Position is null
                ? null
                : input.Position switch
                {
                    "top" => Position.Top,
                    "bottom" => Position.Bottom,
                    _ => Position.Unknown
                }
        };

        return updateList.Refresh();
    }
}