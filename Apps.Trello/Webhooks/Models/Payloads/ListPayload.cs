using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class ListPayload
{
    [Display("List ID")]
    [JsonProperty("id")]
    public string ListId { get; set; }
    
    [Display("List name")]
    [JsonProperty("name")]
    public string ListName { get; set; }
}