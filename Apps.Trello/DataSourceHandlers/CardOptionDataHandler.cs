using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.Card;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;
using Apps.Trello.Extensions;
using Apps.Trello.Webhooks.Models;

namespace Apps.Trello.DataSourceHandlers
{
    public class CardOptionDataHandler(InvocationContext invocationContext, [ActionParameter] CardOptionFilter card)
    : TrelloInvocable(invocationContext), IAsyncDataSourceHandler
    {
        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
            CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(card.BoardId))
                throw new("You need to specify Board ID first");

            var board = new Board(card.BoardId);
            var cards = await board.GetAllCardsAsync(Creds, ct: cancellationToken);

            return cards
                .Where(x => context.SearchString is null ||
                            x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(x => x.DateLastActivity)
                .DistinctBy(x => x.Id)
                .Take(30)
                .ToDictionary(x => x.Id, x => x.Name);
        }
    }
}