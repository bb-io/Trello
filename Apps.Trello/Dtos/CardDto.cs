using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Dtos
{
    public class CardDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string ListName { get; set; }
    }
}
