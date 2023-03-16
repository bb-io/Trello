using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Requests
{
    public class CreateListRequest
    {
        public string BoardId { get; set; }

        public string ListName { get; set;}
    }
}
