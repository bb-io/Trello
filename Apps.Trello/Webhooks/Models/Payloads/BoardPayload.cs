using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class BoardPayload
{
    [Display("Board ID")]
    [JsonProperty("id")]
    public string BoardId { get; set; }
    
    [Display("Board name")]
    [JsonProperty("name")]
    public string BoardName { get; set; }
    
    [Display("Board short link")]
    [JsonProperty("shortLink")]
    public string BoardShortLink { get; set; }
}