using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Apps.Trello.Models.Requests;
using Apps.Trello.Models.Responses;
using Apps.Trello.Dtos;
using Manatee.Trello;
using System;
using Blackbird.Applications.Sdk.Common.Actions;

namespace Apps.Trello
{
    [ActionList]
    public class Actions
    {
        [Action("Get board", Description = "Get board details by id")]
        public GetBoardResponse GetBoardById(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders, 
            [ActionParameter] GetBoardRequest input)
        {
            ConnectToTrello(authenticationCredentialsProviders);
            var board = GetBoardData(input.BoardId);
            return new GetBoardResponse()
            {
                Name = board.Name,
                Description = board.Description,
                Url = board.Url,
                LastViewed = board.LastViewed
            };
        }

        [Action("Get board cards", Description = "Get board cards")]
        public GetBoardCardsResponse GetBoardCards(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] GetBoardRequest input)
        {
            ConnectToTrello(authenticationCredentialsProviders);
            var board = GetBoardData(input.BoardId);
            board.Cards.Refresh().Wait();
            var cards = board.Cards.Select(c => new CardDto()
            {
                Name = c.Name,
                Description = c.Description,
                ListName = c.List.Name
            }).ToList();

            return new GetBoardCardsResponse()
            {
                BoardName = board.Name,
                Cards = cards
            };
        }

        [Action("Get board lists", Description = "Get board lists")]
        public GetBoardListsResponse GetBoardLists(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] GetBoardRequest input)
        {
            ConnectToTrello(authenticationCredentialsProviders);
            var board = GetBoardData(input.BoardId);
            board.Lists.Refresh().Wait();
            var lists = board.Lists.Select(l => new ListDto()
            {
                Id = l.Id,
                Name = l.Name,
            }).ToList();

            return new GetBoardListsResponse()
            {
                Lists = lists,
            };
        }

        [Action("Create card", Description = "Create card on board")]
        public void CreateCard(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] CreateCardRequest input)
        {
            ConnectToTrello(authenticationCredentialsProviders);
            var board = GetBoardData(input.BoardId);
            board.Lists.Refresh().Wait();
            board.Lists.First(l => l.Id == input.ListId).Cards.Add(input.CardName, input.CardDescription, Position.Top).Wait();
        }

        [Action("Create list", Description = "Create list on board")]
        public void CreateList(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
            [ActionParameter] CreateListRequest input)
        {
            ConnectToTrello(authenticationCredentialsProviders);
            var board = GetBoardData(input.BoardId);
            board.Lists.Add(input.ListName, Position.Bottom);
        }

        private Board GetBoardData(string boardId)
        {
            var board = new Board(boardId);
            board.Refresh().Wait();
            return board;
        }

        private void ConnectToTrello(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders)
        {
            TrelloAuthorization.Default.AppKey = authenticationCredentialsProviders.First(p => p.KeyName == "apiKey").Value;
            TrelloAuthorization.Default.UserToken = authenticationCredentialsProviders.First(p => p.KeyName == "userToken").Value;
        }
    }
}
