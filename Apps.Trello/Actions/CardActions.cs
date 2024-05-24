using Apps.Trello.Actions.Base;
using Apps.Trello.Models.Entities;
using Apps.Trello.Models.Requests.Board;
using Apps.Trello.Models.Requests.Card;
using Apps.Trello.Models.Requests.List;
using Apps.Trello.Models.Responses.Card;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.System;
using Manatee.Trello;
using System.Collections.Generic;

namespace Apps.Trello.Actions;

[ActionList]
public class CardActions(InvocationContext invocationContext) : TrelloActions(invocationContext)
{
    [Action("List cards", Description = "List all board cards")]
    public async Task<ListCardsResponse> ListCards([ActionParameter] BoardCardsFilterRequest input)
    {
        var board = await GetBoardData(input.BoardId);
        board.Cards.Limit = input.Limit ?? 100;
        await board.Cards.Refresh();

        var cards = board.Cards.Select(c => new CardEntity(c)).ToArray();
        return new(cards);
    }
    
    [Action("List assigned cards", Description = "List all cards assigned to the user")]
    public async Task<ListCardsResponse> ListUserCards([ActionParameter] CardFilterRequest request)
    {
        var me = await Client.Me();
        me.Cards.Limit = request.Limit ?? 100;
        
        await me.Cards.Refresh();

        var cards = me.Cards.Select(c => new CardEntity(c)).ToArray();

        return new(cards);
    }

    [Action("Get card", Description = "Get specific card details")]
    public async Task<CardEntity> GetCard([ActionParameter] CardRequest input)
    {
        var card = new Card(input.CardId);
        await card.Refresh();
        await card.List.Refresh();
        
        return new(card);
    }

    [Action("Copy card", Description = "Creates a new card based on another one")]
    public async Task<CardEntity> CopyCard([ActionParameter] ListRequest list, [ActionParameter] CopyCardRequest input)
    {
        var card = new Card(input.CardId);
        await card.Refresh();
        await card.List.Refresh();

        var board = await GetBoardData(list.BoardId);
        await board.Lists.Refresh();

        var CopyOptions = input.GetCopyOptions();

        var newcard = await board.Lists.First(l => l.Id == list.ListId).Cards.Add(card, CopyOptions);

        return new(newcard);
    }


    [Action("Create card", Description = "Create card on board")]
    public async Task<CardEntity> CreateCard(
        [ActionParameter] ListRequest list,
        [ActionParameter] CreateCardRequest input)
    {
        var board = await GetBoardData(list.BoardId);
        await board.Lists.Refresh();

        var card = await board.Lists.First(l => l.Id == list.ListId).Cards
            .Add(input.CardName, input.CardDescription, Position.Top, input.DueDate);

        return new(card);
    }
    
    [Action("Update card", Description = "Update specific card")]
    public async Task<CardEntity> UpdateCard(
        [ActionParameter] ListCardRequest card,
        [ActionParameter] UpdateCardRequest input)
    {
        var result = new Card(card.CardId)
        {
            Name = input.Name,
            Description = input.Description,
            IsComplete = input.IsComplete,
            IsArchived = input.IsArchived,
            DueDate = input.DueDate
        };

        if (card.ListId is not null)
        {
            var list = new List(card.ListId);
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