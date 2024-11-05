using Apps.Trello.Models.Entities;
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

        public List<ChecklistEntity> Checklists { get; set; }

        public List<string> Comments { get; set; }

        public List<cardAttachment> Attachments { get; set; }

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
            Checklists = card.CheckLists is null ? new List<ChecklistEntity>() : card.CheckLists.Select(c => new ChecklistEntity(c)).ToList();
            Comments = card.Comments is null ? new List<string>() : card.Comments.Select(x => x.Data.Text).ToList();
            Attachments = card.Attachments is null ? new List<cardAttachment>() : card.Attachments.Select(a => new cardAttachment(a)).ToList();
            Position = (int)card.Position;
            ListName = card.List.Name;
            ListID = card.List.Id;
            Description = card.Description;
            CreationDate = card.CreationDate;
            LastActivity = DateTime.Now;
        }

    }

    public class cardAttachment
    {
        [Display("Attachment ID")]
        public string attachmentID { get; set; }

        [Display("Attachment name")]
        public string attachmentName { get; set; }

        [Display("Attachment type")]
        public string attachmentType { get; set; }

        [Display("Attachment date")]
        public DateTime attachmentDate { get; set; }

        [Display("Attachment link")]
        public string attachmentLink { get; set; }

        public cardAttachment(IAttachment attachment) 
        {
            attachmentID = attachment.Id;
            attachmentName = attachment.Name;
            attachmentType = (bool)attachment.IsUpload  ? "file" : "link";
            attachmentDate = attachment.CreationDate;
            attachmentLink = attachment.Url;

        }
    }
}
