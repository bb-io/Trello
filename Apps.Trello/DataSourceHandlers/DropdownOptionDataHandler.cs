using Apps.Trello.Invocables;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.CustomField;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.DataSourceHandlers
{
    public class DropdownOptionDataHandler(InvocationContext invocationContext, [ActionParameter] CardRequest input, [ActionParameter] SetDropdownCustomFieldRequest CustomField)
    : TrelloInvocable(invocationContext), IAsyncDataSourceHandler
    {
        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(input.CardId) || string.IsNullOrWhiteSpace(CustomField.CustomFieldId))
                throw new Exception("You should input Card ID and Custom Field first.");

            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();
            return card.CustomFields.First(x => x.Definition.Id == CustomField.CustomFieldId).Definition.Options
            .Where(x => (context.SearchString == null ||
                        x.Text.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase)))
            .Take(20)
            .ToDictionary(x => x.Id, x => x.Text);

        }
    }
}
