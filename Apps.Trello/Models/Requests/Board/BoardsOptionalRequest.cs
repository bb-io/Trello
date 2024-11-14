using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.Board;

public class BoardsOptionalRequest
{
    [Display("Board IDs")]
    [DataSource(typeof(BoardDataHandler))]
    public IEnumerable<string>? BoardIds { get; set; }
}