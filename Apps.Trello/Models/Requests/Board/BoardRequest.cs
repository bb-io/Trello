using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.Board;

public class BoardRequest
{
    [Display("Board")]
    [DataSource(typeof(BoardDataHandler))]
    public string BoardId { get; set; }
}