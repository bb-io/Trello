using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Polling.Models.Response;

public class CardsCommentsResponse
{
    [Display("Card comments")]
    public List<CardCommentResponse> CardComments { get; set; } = new();
}