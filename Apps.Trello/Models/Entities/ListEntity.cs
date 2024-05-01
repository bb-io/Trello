using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Entities;

public class ListEntity
{
    [Display("List ID")] public string Id { get; set; }

    public string Name { get; set; }

    public double Position { get; set; }

    [Display("Is archived")] public bool IsArchived { get; set; }

    [Display("Is subscribed")] public bool IsSubscribed { get; set; }

    public ListEntity(IList list)
    {
        Id = list.Id;
        Name = list.Name;
        Position = list.Position.Value;
        IsArchived = list.IsArchived ?? false;
        IsSubscribed = list.IsSubscribed ?? false;
    }
}