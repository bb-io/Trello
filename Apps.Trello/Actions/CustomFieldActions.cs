
using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.CustomField;
using Apps.Trello.Models.Responses.CustomField;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;
using System.Linq;
using System.Text.RegularExpressions;

namespace Apps.Trello.Actions
{
    [ActionList]
    public class CustomFieldActions(InvocationContext invocationContext) : TrelloActions(invocationContext)
    {
        [Action("Set card text custom field", Description = "Update the value of a text custom field in a card")]
        public async Task<CustomFieldEntity> SetTextCustomfield([ActionParameter] CardRequest input, [ActionParameter] SetTextCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var updateField = await card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId).Definition.SetValueForCard(card,CustomField.Text);
            await card.Refresh();

            return new(updateField);
        }

        [Action("Set card number custom field", Description = "Update the numeric value of a custom field in a card")]
        public async Task<CustomFieldEntity> SetNumberCustomfield([ActionParameter] CardRequest input, [ActionParameter] SetNumberCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var updateField = await card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId).Definition.SetValueForCard(card, CustomField.Number);
            await card.Refresh();

            return new(updateField);
        }

        [Action("Set card date custom field", Description = "Update the date value of a custom field in a card")]
        public async Task<CustomFieldEntity> SetDateCustomfield([ActionParameter] CardRequest input, [ActionParameter] SetDateCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var updateField = await card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId).Definition.SetValueForCard(card, CustomField.Date);
            await card.Refresh();

            return new(updateField);
        }

        [Action("Set card dropdown custom field", Description = "Update the numeric value of a custom field in a card")]
        public async Task<CustomFieldEntity> SetDropdownCustomfield([ActionParameter] CardRequest input, [ActionParameter] SetDropdownCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();
            var option = card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId).Definition.Options.First(x => x.Id == CustomField.OptionId);
            var updateField = await card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId).Definition.SetValueForCard(card, option);
            await card.Refresh();

            return new(updateField);
        }

        [Action("List card custom fields", Description = "Get specific card custom field details as text")]
        public async Task<ListCustomFieldsResponse> GetCustomfields([ActionParameter] CardRequest input)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var fields = card.CustomFields.Select(c => new CustomFieldEntity(c)).ToArray();
            return new(fields);
        }

        [Action("Get text custom field value", Description = "Get the text value of a specific custom field on a card")]
        public async Task<string> GetTextCustomfield([ActionParameter] CardRequest input, [ActionParameter] GetTextCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var result = card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId);
            return result is null ? "" : Regex.Match(result.ToString(), @"- (.*?)$").Groups[1].Value;
        }

        [Action("Get number custom field value", Description = "Get the numeric value of a specific custom field on a card")]
        public async Task<double?> GetNumberCustomfield([ActionParameter] CardRequest input, [ActionParameter] GetNumberCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var result = card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId);
            return result is null ? null : double.Parse(Regex.Match(result.ToString(), @"- (.*?)$").Groups[1].Value);
        }

        [Action("Get date custom field value", Description = "Get the datetime value of a specific custom field on a card")]
        public async Task<DateTime?> GetDateCustomfield([ActionParameter] CardRequest input, [ActionParameter] GetDateCustomFieldRequest CustomField)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            await card.Board.CustomFields.Refresh();

            var result = card.CustomFields.FirstOrDefault(x => x.Id == CustomField.CustomFieldId);
            return result is null ? null : DateTime.Parse(Regex.Match(result.ToString(), @"- (.*?)$").Groups[1].Value);
        }

    }
}
