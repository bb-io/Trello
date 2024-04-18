using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.Card;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.DataSourceHandlers;

public class CardDataHandler : TrelloInvocable, IAsyncDataSourceHandler
{
    private readonly CardRequest _card;

    public CardDataHandler(InvocationContext invocationContext, [ActionParameter] CardRequest card) : base(invocationContext)
    {
        _card = card;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_card.BoardId))
            throw new("You need to specify Board ID first");
        
        var board = new Board(_card.BoardId);
        await board.Refresh(ct: cancellationToken);
        await board.Cards.Refresh(ct: cancellationToken);

        return board.Cards
            .Where(x => context.SearchString is null ||
                        x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
            .OrderByDescending(x => x.CreationDate)
            .Take(30)
            .ToDictionary(x => x.Id, x => x.Name);
    }
}