﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Trello.Actions;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.Checklist;
using TrelloTests.Base;

namespace Tests.Trello
{
    [TestClass]
    public class ChecklistTests :TestBase
    {
        [TestMethod]
        public async Task UpdateChcklistItem_IsSuccess()
        {
            var action = new ChecklistActions(InvocationContext);
            var input = new CardRequest
            {
                BoardId= "5176af831f22073e1e0012e3",
                CardId = "67cf3de23bebfbadae1f2b25"
            };
            var iteminfo = new UpdateChecklistItemRequest
            {
                ChecklistID = "67cf3de23bebfbadae1f2cd2",
                CheckItemID = "67cf3de23bebfbadae1f2cd3",
                State = "Complete"
            };
            var response = await action.UpdateChecklistItem(input, iteminfo);
            Assert.IsNotNull(response);
        }  
    }
}
