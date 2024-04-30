using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Checklist
{
    public class GetChecklistRequest
    {
        [Display("Checklist ID")]
        public string ChecklistID { get; set; }
    }
}
