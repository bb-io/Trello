using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class UpdateCardRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    [Display("Is complete")]
    public bool? IsComplete { get; set; }
    
    [Display("Is archived")]
    public bool? IsArchived { get; set; }
}