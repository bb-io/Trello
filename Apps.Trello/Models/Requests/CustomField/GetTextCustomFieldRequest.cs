using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.CustomField
{
    public class GetTextCustomFieldRequest
    {
        [Display("Custom field ID"), DataSource(typeof(TextCustomFieldDataHandler))]
        public string CustomFieldId { get; set; }
    }
}
