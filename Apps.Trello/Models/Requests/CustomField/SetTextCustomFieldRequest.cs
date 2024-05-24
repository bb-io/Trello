using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Requests.CustomField
{
    public class SetTextCustomFieldRequest
    {
        [Display("Custom field ID"), DataSource(typeof(TextOnlyCustomFieldDataHandler))]
        public string CustomFieldId { get; set; }

        public string Text { get; set; }
    }
}
