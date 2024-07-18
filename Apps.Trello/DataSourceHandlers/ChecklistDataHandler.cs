using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.Card;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.DataSourceHandlers
{
    public class ChecklistDataHandler : TrelloInvocable, IAsyncDataSourceHandler
    {
        private readonly CardRequest _card;

        public ChecklistDataHandler(InvocationContext invocationContext, [ActionParameter] CardRequest card) : base(invocationContext)
        {
            _card = card;
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(_card.CardId))
                throw new("You need to specify Card ID first");
            
            var card = new Card(_card.CardId);
            await card.Refresh(ct: cancellationToken);
            
            return card.CheckLists
                .Where(x => context.SearchString is null ||
                            x.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .Take(30)
                .ToDictionary(x => x.Id, x => x.Name);
        }
    }
}
