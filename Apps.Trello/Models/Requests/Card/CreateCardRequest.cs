using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class CreateCardRequest
{
    [Display("Card name")]
    public string CardName { get; set; }

    [Display("Card description")]
    public string? CardDescription { get; set; }

    [Display("Due date")]
    public DateTime? DueDate { get; set; }
}