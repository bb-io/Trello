using Apps.Trello.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Trello.Models.Requests.List;

public class UpdateListRequest
{
    public string? Name { get; set; }

    [Display("Is archived")] public bool? IsArchived { get; set; }

    [Display("Is subscribed")] public bool? IsSubscribed { get; set; }
    
    [StaticDataSource(typeof(ListPositionDataHandler))]
    public string? Position { get; set; }
}