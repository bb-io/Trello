using Apps.Trello.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Responses.Checklist
{
    public class GetChecklistsResponse
    {
        public IEnumerable<ChecklistEntity> Checklists {get; set;}
    }
}
