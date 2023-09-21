using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Webhooks.Models.Payloads;

public class IdPayload
{
    [Display("ID")]
    public string Id { get; set; }
}