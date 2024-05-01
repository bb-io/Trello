using Apps.Trello.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
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
        [StaticDataSource(typeof(CheckitemStateDataHandler))]
        public string State { get; set; }

    }
}
