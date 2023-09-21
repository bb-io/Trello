﻿using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCreatedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_create_card";
    
    public CardCreatedHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}