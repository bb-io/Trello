using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Apps.Trello.Models.Entities
{
    public class CustomFieldEntity
    {
        [Display("Custom field ID")]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }


        public CustomFieldEntity(ICustomField customField)
        {
            Id = customField.Id;
            Name = customField.Definition.Name;
            Type = customField.Definition.Type is null ? "" : customField.Definition.Type.ToString();
            Value = Regex.Match(customField.ToString(), @"- (.*?)$").Groups[1].Value;
        }
    }
}
