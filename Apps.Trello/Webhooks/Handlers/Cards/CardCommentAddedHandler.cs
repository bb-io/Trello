﻿using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Webhooks.Handlers.Base;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Trello.Webhooks.Handlers.Cards;

public class CardCommentAddedHandler : TrelloWebhookHandler
{
    protected override string Event => "action_comment_on_card";
    
    public CardCommentAddedHandler([WebhookParameter] BoardRequest input) : base(input)
    {
    }
}