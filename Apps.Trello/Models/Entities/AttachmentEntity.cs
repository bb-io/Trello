using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Manatee.Trello;

namespace Apps.Trello.Models.Entities
{
    public class AttachmentEntity
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? Name { get; set; }
        public string? MimeType { get; set; }
        public bool IsUpload { get; set; }
        public DateTime? Date { get; set; }

        public AttachmentEntity() { }

        public AttachmentEntity(IAttachment attachment)
        {
            Id = attachment.Id;
            Url = attachment.Url;
            Name = attachment.Name;
            MimeType = attachment.MimeType;
            IsUpload = attachment.IsUpload ?? false;
            Date = attachment.Date;
        }
    }
}
