using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.List;

public class CreateListRequest : BoardRequest
{
    [Display("List name")] public string ListName { get; set; }
}