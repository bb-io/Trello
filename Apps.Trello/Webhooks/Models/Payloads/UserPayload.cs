using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class UserPayload
{
    [Display("User ID")]
    [JsonProperty("id")]
    public string UserId { get; set; }
    
    [Display("User name")]
    [JsonProperty("name")]
    public string UserName { get; set; }
}