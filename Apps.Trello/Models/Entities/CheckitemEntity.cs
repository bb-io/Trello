using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Entities
{
    public class CheckitemEntity
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string State { get; set; }

        public CheckitemEntity(ICheckItem item)
        {
            Id = item.Id;
            Name = item.Name;
            State = item.State.Value.ToString();
        }

    }
}
