using Blackbird.Applications.Sdk.Common;
using Manatee.Trello;

namespace Apps.Trello.Models.Responses.Card
{
    public class GetCardResponse
    {
        [Display("Card ID")]
        public string ID { get; set; }

        public string Url { get; set; }

        [Display("Card name")]
        public string Name { get; set; }

        public List<ICheckList> Checklists { get; set; }

        public List<string> Comments { get; set; }

        public List<IAttachment> Attachments { get; set; }

        [Display("List name")]
        public string ListName { get; set; }

        [Display("List ID")]
        public string ListID { get; set; }

        public int Position { get; set; }

        public string Description { get; set; }

        [Display("Creation date")]
        public DateTime CreationDate {get; set; }

        [Display("Last activity date")]
        public DateTime LastActivity { get; set; }

        public GetCardResponse(ICard card) 
        {
            ID = card.Id; 
            Url = card.Url;
            Name = card.Name;
            Checklists = card.CheckLists is null ? new List<ICheckList>() : card.CheckLists.ToList();
            Comments = card.Comments is null ? new List<string>() : card.Comments.Select(x => x.Data.Text).ToList();
            Attachments = card.Attachments is null ? new List<IAttachment>() : card.Attachments.ToList();
            Position = (int)card.Position;
            ListName = card.List.Name;
            ListID = card.List.Id;
            Description = card.Description;
            CreationDate = card.CreationDate;
            LastActivity = DateTime.Now;
        }

    }
}
