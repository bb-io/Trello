using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class SmallCardPayload
{
    [Display("Old card name")]
    [JsonProperty("name")]
    public string OldCardName { get; set; }
}