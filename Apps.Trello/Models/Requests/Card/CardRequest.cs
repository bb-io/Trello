using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Models.Requests.Card;

public class CardRequest
{
    [Display("Board")]
    [DataSource(typeof(BoardDataHandler))]
    public string BoardId { get; set; }
    
    [Display("Card ID")]
    [DataSource(typeof(CardDataHandler))]
    public string CardId { get; set; }
}