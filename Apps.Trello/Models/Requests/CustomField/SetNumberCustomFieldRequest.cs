using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.CustomField
{
    public class SetNumberCustomFieldRequest
    {
        [Display("Custom field ID"), DataSource(typeof(NumberCustomFieldDataHandler))]
        public string CustomFieldId { get; set; }

        public double Number { get; set; }
    }
}
