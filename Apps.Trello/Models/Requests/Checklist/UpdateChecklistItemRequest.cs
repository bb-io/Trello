

using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Requests.Checklist
{
    public class UpdateChecklistItemRequest
    {
        [Display("Checklist ID")]
        public string ChecklistID { get; set; }

        [Display("Check Item ID")]
        public string CheckItemID { get; set; }

        [Display("Check Item Name")]
        public string? Name { get; set; }

        [Display("Check Item State")]
        public CheckItemState State { get; set; }

    }
}
