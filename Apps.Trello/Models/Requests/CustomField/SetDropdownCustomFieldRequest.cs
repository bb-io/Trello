using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Manatee.Trello;

namespace Apps.Trello.Models.Requests.CustomField
{
    public class SetDropdownCustomFieldRequest
    {
        [Display("Custom field ID"), DataSource(typeof(DropdownCustomFieldDataHandler))]
        public string CustomFieldId { get; set; }

        [Display("Dropdown option ID"), DataSource(typeof(DropdownOptionDataHandler))]
        public string OptionId { get; set; }
    }
}
