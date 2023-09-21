using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class CardPayload
{
    [Display("Card ID")]
    [JsonProperty("id")]
    public string CardId { get; set; }
    
    [Display("Card name")]
    [JsonProperty("name")]
    public string CardName { get; set; }
    
    [Display("Card short link")]
    [JsonProperty("shortLink")]
    public string CardShortLink { get; set; }
}