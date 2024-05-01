using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.Checklist;
using Apps.Trello.Models.Responses.Checklist;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
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
            await card.Refresh();
            return new GetChecklistsResponse { Checklists = card.CheckLists.Select(x => new ChecklistEntity(x)) };
        }

        [Action("Get card checklist", Description = "Gets a specific checklist from a card")]
        public async Task<ChecklistEntity> GetCardChecklist([ActionParameter] CardRequest input, [ActionParameter] GetChecklistRequest checklist)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            return new ChecklistEntity(card.CheckLists.First(x => checklist.ChecklistID == x.Id));
        }

        [Action("Update checklist item", Description = "Update checklist item")]
        public async Task<CheckitemEntity> UpdateChecklistItem([ActionParameter] CardRequest input,
            [ActionParameter] UpdateChecklistItemRequest iteminfo)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            var checklist = card.CheckLists.First(x => iteminfo.ChecklistID == x.Id);
            var item = checklist.CheckItems.First(x => iteminfo.CheckItemID == x.Id);
            item.State = iteminfo.State == "Complete" ? CheckItemState.Complete : CheckItemState.Incomplete;
            item.Name = String.IsNullOrEmpty(iteminfo.Name) ? item.Name : iteminfo.Name ;
            await item.Refresh();
            return new(item);
        }

        [Action("Search checklist item", Description = "Gets a specific checklist item from a card")]
        public async Task<CheckitemEntity> GetCardChecklist([ActionParameter] CardRequest input, [ActionParameter] SearchItemRequest itemInfo)
        {
            var card = new Card(input.CardId);
            await card.Refresh();
            var List = card.CheckLists.First(x => itemInfo.ChecklistID == x.Id);
            return new CheckitemEntity(List.CheckItems.First(x => x.Name == itemInfo.ItemName));
        }
    }
}
