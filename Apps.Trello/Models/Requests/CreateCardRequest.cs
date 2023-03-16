using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Requests
{
    public class CreateCardRequest
    {
        public string BoardId { get; set; }

        public string ListId { get; set; }

        public string CardName { get; set; }

        public string CardDescription { get; set; }
    }
}
