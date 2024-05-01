using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Checklist
{
    public class SearchItemRequest
    {
        [Display("Checklist ID")]
        public string ChecklistID { get; set; }

        [Display("Check item name")]
        public string ItemName { get; set; }
    }
}
