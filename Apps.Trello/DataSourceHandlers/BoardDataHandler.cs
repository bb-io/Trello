using Apps.Trello.Invocables;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Trello.DataSourceHandlers;

public class BoardDataHandler : TrelloInvocable, IAsyncDataSourceHandler
{
    public BoardDataHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        var me = await Client.Me(ct: cancellationToken);
        await me.Boards.Refresh(ct: cancellationToken);

        return me.Boards
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(x => x.CreationDate)
            .Take(30)
            .ToDictionary(x => x.Id, x => x.Name);
    }
}