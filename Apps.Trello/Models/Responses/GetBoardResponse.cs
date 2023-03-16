using Apps.Trello.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Responses
{
    public class GetBoardResponse
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public DateTime? LastViewed { get; set; }
    }
}
