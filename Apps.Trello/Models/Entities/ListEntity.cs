using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Entities;

public class ListEntity
{
    [Display("List ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    public string Position { get; set; }
    
    public ListEntity(IList list)
    {
        Id = list.Id;
        Name = list.Name;
        Position = list.Position.ToString();
    }
}