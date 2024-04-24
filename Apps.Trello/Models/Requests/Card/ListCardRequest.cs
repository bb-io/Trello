using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.Card;

public class ListCardRequest : CardRequest
{
    [Display("List ID")]
    [DataSource(typeof(ListCardDataHandler))]
    public string? ListId { get; set; }
}