using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.List;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.DataSourceHandlers;

public class ListDataHandler : TrelloInvocable, IAsyncDataSourceHandler
{
    private readonly ListRequest _list;

    public ListDataHandler(InvocationContext invocationContext, [ActionParameter] ListRequest list) : base(invocationContext)
    {
        _list = list;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_list.BoardId))
            throw new("You need to specify Board ID first");
        
        var board = new Board(_list.BoardId);
        await board.Refresh(ct: cancellationToken);
        await board.Lists.Refresh(ct: cancellationToken);

        return board.Lists
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(x => x.CreationDate)
            .Take(30)
            .ToDictionary(x => x.Id, x => x.Name);
    }
}