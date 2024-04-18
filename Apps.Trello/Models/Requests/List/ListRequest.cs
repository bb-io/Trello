using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.List;

public class ListRequest
{
    [Display("Board")]
    [DataSource(typeof(BoardDataHandler))]
    public string BoardId { get; set; }
    
    [Display("List ID")]
    [DataSource(typeof(ListDataHandler))]
    public string ListId { get; set; }
}