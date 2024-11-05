using Apps.Trello.Models.Entities;
using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Polling.Models.Response;

public class CardCommentResponse(IAction action)
{
    [Display("Comment text")]
    public string Text { get; set; } = action.Data.Text;

    [Display("Card")]
    public CardEntity Card { get; set; } = new CardEntity(action.Data.Card);
}