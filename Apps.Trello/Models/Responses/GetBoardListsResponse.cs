﻿using Apps.Trello.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Responses
{
    public class GetBoardListsResponse
    {
        public List<ListDto> Lists { get; set; }
    }
}
