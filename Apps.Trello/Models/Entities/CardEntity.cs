using Apps.Trello.Models.Dtos;
using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Entities;

public class CardEntity
{
    [Display("Card ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }

    public string Description { get; set; }

    [Display("List name")] public string ListName { get; set; }

    [Display("Creation date")] public DateTime CreationDate { get; set; }

    [Display("Last activity")] public DateTime? LastActivity { get; set; }

    public string Position { get; set; }

    [Display("URL")] public string Url { get; set; }

    [Display("Checklists")]
    public IEnumerable<ChecklistEntity> Lists { get; set; }

    public CardEntity(ICard card)
    {
        Id = card.Id;
        Name = card.Name;
        Description = card.Description;
        CreationDate = DateTime.SpecifyKind(card.CreationDate, DateTimeKind.Utc);
        LastActivity = card.LastActivity;
        Position = card.Position.ToString();
        Url = card.Url;
        ListName = card.List.Name;
        Lists = card.CheckLists.Select(x => new ChecklistEntity(x));
    }

    public CardEntity(CardDto cardDto)
    {
        Id = cardDto.Id;
        Name = cardDto.Name;
        Description = cardDto.Desc;
        CreationDate = cardDto.Due ?? DateTime.MinValue;
        LastActivity = cardDto.DateLastActivity;
        Position = cardDto.Position.ToString();
        Url = cardDto.Url;
        ListName = cardDto.ListName;
        Lists = cardDto.CheckLists.Select(x => new ChecklistEntity(x));
    }
}