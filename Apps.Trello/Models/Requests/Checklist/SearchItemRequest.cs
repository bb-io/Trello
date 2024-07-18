using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.Checklist
{
    public class SearchItemRequest
    {
        [Display("Checklist ID")]
        [DataSource(typeof(ChecklistDataHandler))]
        public string ChecklistID { get; set; }

        [Display("Check item name")]
        public string ItemName { get; set; }
    }
}
