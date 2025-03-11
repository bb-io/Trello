using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.Checklist;
using Apps.Trello.Models.Responses.Checklist;
using Apps.Trello.Utils;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.Actions
{
    [ActionList]
    public class ChecklistActions : TrelloActions
    {
        public ChecklistActions(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        [Action("List card checklists", Description = "Lists all checklists in a card")]
        public async Task<GetChecklistsResponse> GetCardChecklists([ActionParameter] CardRequest input)
        {
            var card = new Card(input.CardId);
            await ExecuteWithWrapper.ExecuteRefreshWithWrapper(() => card.Refresh());
            return new GetChecklistsResponse { Checklists = card.CheckLists.Select(x => new ChecklistEntity(x)) };
        }

        [Action("Get card checklist", Description = "Gets a specific checklist from a card")]
        public async Task<ChecklistEntity> GetCardChecklist([ActionParameter] CardRequest card, [ActionParameter] GetChecklistRequest input)
        {
            var chk =new CheckList(input.ChecklistID);
            await ExecuteWithWrapper.ExecuteRefreshWithWrapper(() => chk.Refresh());
            return new ChecklistEntity(chk);
        }

        [Action("Update checklist item", Description = "Update checklist item")]
        public async Task<CheckitemEntity> UpdateChecklistItem([ActionParameter] CardRequest input,
            [ActionParameter] UpdateChecklistItemRequest iteminfo)
        {
            var card = new Card(input.CardId);
            await ExecuteWithWrapper.ExecuteRefreshWithWrapper(() => card.Refresh());
            var checklist = card.CheckLists.FirstOrDefault(x => iteminfo.ChecklistID == x.Id);

            if (checklist == null)
            {
                throw new PluginMisconfigurationException("Checklist with the specified ID was not found. Please check your input and try again");
            }

            var item = checklist.CheckItems.FirstOrDefault(x => iteminfo.CheckItemID == x.Id);

            if (item == null)
            {
                throw new PluginMisconfigurationException("Check item with the specified ID was not found. Please check your input and try again");
            }

            item.State = iteminfo.State == "Complete" ? CheckItemState.Complete : CheckItemState.Incomplete;
            item.Name = String.IsNullOrEmpty(iteminfo.Name) ? item.Name : iteminfo.Name ;
            await item.Refresh();
            return new(item);
        }

        [Action("Find checklist item", Description = "Gets a specific checklist item from a card")]
        public async Task<CheckitemEntity> SearchItem([ActionParameter] CardRequest card, [ActionParameter] SearchItemRequest input)
        {
            var chk = new CheckList(input.ChecklistID);
            await ExecuteWithWrapper.ExecuteRefreshWithWrapper(() => chk.Refresh());
            return new CheckitemEntity(chk.CheckItems.First(x => x.Name == input.ItemName));
        }

        [Action("Find checklist", Description = "Gets the first matching checklist in a card")]
        public async Task<ChecklistEntity> FindCardChecklists([ActionParameter] CardRequest input,
            [Display("Checklist name")][ActionParameter] string checklistName )
        {
            var card = new Card(input.CardId);
            await ExecuteWithWrapper.ExecuteRefreshWithWrapper(() => card.Refresh());

            if (card.CheckLists.Any(x => x.Name == checklistName))
            {
                return new(card.CheckLists.FirstOrDefault(x => x.Name == checklistName));
            }
            else { return null; }
        }
    }
}
