using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.CustomField
{
    public class GetDateCustomFieldRequest
    {
        [Display("Custom field ID"), DataSource(typeof(DateCustomFieldDataHandler))]
        public string CustomFieldId { get; set; }
    }
}
