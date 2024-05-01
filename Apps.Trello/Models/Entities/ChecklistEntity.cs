using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Entities
{
    public class ChecklistEntity
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [Display("Check Items")]
        public IEnumerable<CheckitemEntity> CheckItems { get; set; }

        public ChecklistEntity(ICheckList list)
        {
            Id = list.Id;
            Name = list.Name;
            CheckItems = list.CheckItems.Select(x => new CheckitemEntity(x));
        }

    }
}
