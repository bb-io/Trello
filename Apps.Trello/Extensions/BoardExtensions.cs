using Apps.Trello.Constants;
using Apps.Trello.Models.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Manatee.Trello;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Trello.Extensions;

public static class BoardExtensions
{
    public static async Task<List<CardDto>> GetAllCardsAsync(this Board board, AuthenticationCredentialsProvider[] creds,
        bool fillSubObjects = false,
        CancellationToken ct = default)
    {
        var apiKey = creds.Get(CredsNames.ApiKey).Value;
        var apiToken = creds.Get(CredsNames.UserToken).Value;
        var limit = 500;

        var allCards = new List<CardDto>();
        string? before = null;

        while (true)
        {
            var url = $"https://api.trello.com/1/boards/{board.Id}/cards?key={apiKey}&token={apiToken}&limit={limit}";

            if (before != null)
            {
                url += $"&before={before}";
            }

            var restClient = new RestClient();
            var request = new RestRequest(url);

            var response = await restClient.ExecuteAsync(request, ct);
            if (response.IsSuccessStatusCode == false)
                throw new Exception(response.ErrorMessage);

            var currentBatch = JsonConvert.DeserializeObject<List<CardDto>>(response.Content!);
            if (currentBatch == null || currentBatch.Count == 0)
            {
                break;
            }

            allCards.AddRange(currentBatch);
            before = currentBatch.Last().Id;
        }

        if (fillSubObjects)
        {
            allCards = allCards.Select(async x =>
            {
                var card = new Card(x.Id);
                await card.Refresh(ct: ct);
                x.ListName = card.List.Name;
                x.Position = card.Position;
                x.CheckLists = card.CheckLists;
                return x;
            }).Select(x => x.Result).ToList();
        }

        return allCards;
    }
}