using Manatee.Trello;

namespace Apps.Trello.Models.Dtos;

public class CardDto
{
    public string Id { get; set; }
    public Badges Badges { get; set; }
    public List<CheckItemState> CheckItemStates { get; set; }
    public bool Closed { get; set; }
    public bool DueComplete { get; set; }
    public DateTime DateLastActivity { get; set; }
    public string Desc { get; set; }
    public DescData DescData { get; set; }
    public DateTime? Due { get; set; }
    public object DueReminder { get; set; }
    public object Email { get; set; }
    public string IdBoard { get; set; }
    public List<string> IdChecklists { get; set; }
    public string IdList { get; set; }
    public List<string> IdMembers { get; set; }
    public List<string> IdMembersVoted { get; set; }
    public int IdShort { get; set; }
    public object IdAttachmentCover { get; set; }
    public List<Label> Labels { get; set; }
    public List<string> IdLabels { get; set; }
    public bool ManualCoverAttachment { get; set; }
    public string Name { get; set; }
    public double Pos { get; set; }
    public string ShortLink { get; set; }
    public string ShortUrl { get; set; }
    public object Start { get; set; }
    public bool Subscribed { get; set; }
    public string Url { get; set; }
    public Cover Cover { get; set; }
    public bool IsTemplate { get; set; }
    public object CardRole { get; set; }

    public string ListName { get; set; }
    public Position Position { get; set; }
    public ICheckListCollection CheckLists { get; set; }
}

public class Badges
{
    public AttachmentsByType AttachmentsByType { get; set; }
    public bool Location { get; set; }
    public int Votes { get; set; }
    public bool ViewingMemberVoted { get; set; }
    public bool Subscribed { get; set; }
    public string Fogbugz { get; set; }
    public int CheckItems { get; set; }
    public int CheckItemsChecked { get; set; }
    public object CheckItemsEarliestDue { get; set; }
    public int Comments { get; set; }
    public int Attachments { get; set; }
    public bool Description { get; set; }
    public object Due { get; set; }
    public bool DueComplete { get; set; }
    public object Start { get; set; }
}

public class AttachmentsByType
{
    public Trello Trello { get; set; }
}

public class Trello
{
    public int Board { get; set; }
    public int Card { get; set; }
}

public class CheckItemState
{
    public string IdCheckItem { get; set; }
    public string State { get; set; }
}

public class DescData
{
    public Dictionary<string, string> Emoji { get; set; }
}

public class Label
{
    public string Id { get; set; }
    public string IdBoard { get; set; }
    public string Name { get; set; }
    public string Color { get; set; }
    public int Uses { get; set; }
}

public class Cover
{
    public object IdAttachment { get; set; }
    public string Color { get; set; }
    public object IdUploadedBackground { get; set; }
    public string Size { get; set; }
    public string Brightness { get; set; }
    public object IdPlugin { get; set; }
}
