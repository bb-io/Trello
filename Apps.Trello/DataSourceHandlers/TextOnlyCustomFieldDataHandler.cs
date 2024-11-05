using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.Card;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.DataSourceHandlers
{
    public class TextOnlyCustomFieldDataHandler(InvocationContext invocationContext, [ActionParameter] CardRequest input)
    : TrelloInvocable(invocationContext), IAsyncDataSourceHandler
    {
        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input.CardId))
                throw new Exception("You should input Card ID first.");

            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            return card.CustomFields
            .Where(x => x.Definition.Type == CustomFieldType.Text &&
                        (context.SearchString == null ||
                        x.Definition.Name.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)))
            .Take(20)
            .ToDictionary(x => x.Definition.Id, x => x.Definition.Name);
        }
    }
}
