﻿using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Responses.Card;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Manatee.Trello;

namespace Apps.Trello.Actions;

[ActionList]
public class CardActions : TrelloActions
{
    public CardActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List cards", Description = "List all board cards")]
    public async Task<ListCardsResponse> ListCards([ActionParameter] BoardRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        await board.Cards.Refresh();

        var cards = board.Cards.Select(c => new CardEntity(c)).ToArray();

        return new(cards);
    }
    
    [Action("List assigned cards", Description = "List all cards assigned to the user")]
    public async Task<ListCardsResponse> ListUserCards()
    {
        var me = await Client.Me();
        await me.Cards.Refresh();

        var cards = me.Cards.Select(c => new CardEntity(c)).ToArray();

        return new(cards);
    }

    [Action("Get card", Description = "Get specific card details")]
    public async Task<CardEntity> GetCard([ActionParameter] CardRequest input)
    {
        var card = new Card(input.CardId);
        await card.Refresh();

        return new(card);
    }

    [Action("Create card", Description = "Create card on board")]
    public async Task<CardEntity> CreateCard([ActionParameter] CreateCardRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        await board.Lists.Refresh();

        var card = await board.Lists.First(l => l.Id == input.ListId).Cards
            .Add(input.CardName, input.CardDescription, Position.Top, input.DueDate);

        return new(card);
    }
    
    [Action("Update card", Description = "Update specific card")]
    public async Task<CardEntity> UpdateCard(
        [ActionParameter] CardRequest card,
        [ActionParameter] UpdateCardRequest input)
    {
        var result = new Card(card.CardId)
        {
            Name = input.Name,
            Description = input.Description,
            IsComplete = input.IsComplete,
            IsArchived = input.IsArchived,
        };

        if (input.ListId is not null)
        {
            var list = new List(input.ListId);
            await list.Refresh();
            
            result.List = list;
        }

        await result.Refresh();
        return new(result);
    }
    
    [Action("Delete card", Description = "Delete specific card")]
    public Task DeleteCard([ActionParameter] CardRequest input)
        => new Card(input.CardId).Delete();
}