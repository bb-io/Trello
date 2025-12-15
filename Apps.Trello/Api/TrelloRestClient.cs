using Apps.Trello.Models.Entities;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;
using System.Net;

namespace Apps.Trello.Api;

public class TrelloRestClient(List<AuthenticationCredentialsProvider> credentialsProviders) : BlackBirdRestClient(new()
{
    BaseUrl = new Uri("https://api.trello.com/1"),
    ThrowOnAnyError = false
})
{
    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var content = response.Content ?? string.Empty;

        if (response.StatusCode == HttpStatusCode.Unauthorized &&
            content.Contains("invalid key", StringComparison.OrdinalIgnoreCase))
        {
            return new PluginMisconfigurationException(
                "Trello connection is invalid (invalid key). Please reconnect Trello app.");
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized &&
            content.Contains("invalid token", StringComparison.OrdinalIgnoreCase))
        {
            return new PluginMisconfigurationException(
                "Trello connection is invalid (invalid token). Please reconnect Trello app.");
        }

        return new PluginApplicationException(content);
    }

    public async Task<List<CardEntity>> PaginateCardsAsync(string boardId, DateTime? startDate, DateTime? endDate)
    {
        const int limit = 10000;
        var cardsRequest = new TrelloRestRequest($"/boards/{boardId}/cards", Method.Get, credentialsProviders)
            .AddParameter("limit", limit, ParameterType.QueryString)
            .AddParameter("fields", "id,name,url", ParameterType.QueryString);

        if (startDate.HasValue)
        {
            cardsRequest = cardsRequest.AddParameter("since", startDate.Value.ToUniversalTime().ToString("o"),
                ParameterType.QueryString);
        }
        
        if (endDate.HasValue)
        {
            cardsRequest = cardsRequest.AddParameter("before", endDate.Value.ToUniversalTime().ToString("o"),
                ParameterType.QueryString);
        }

        var allCards = new List<CardEntity>();
        do
        {
            var cards = await ExecuteWithErrorHandling<List<CardEntity>>(cardsRequest);
            allCards.AddRange(cards);
            
            if (cards.Count < limit)
            {
                break;
            }

            var first = cards.Last();
            cardsRequest = cardsRequest.AddOrUpdateParameter("before", first.Id, ParameterType.QueryString);
        } while (true);

        allCards = allCards.DistinctBy(x => x.Id).ToList();
        return allCards;
    }
}