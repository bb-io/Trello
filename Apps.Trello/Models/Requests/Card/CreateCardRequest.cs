using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card;

public class CreateCardRequest : BoardRequest
{
    [Display("List ID")]
    public string ListId { get; set; }

    [Display("Card name")]
    public string CardName { get; set; }

    [Display("Card description")]
    public string? CardDescription { get; set; }

    [Display("Due date")]
    public DateTime? DueDate { get; set; }
}