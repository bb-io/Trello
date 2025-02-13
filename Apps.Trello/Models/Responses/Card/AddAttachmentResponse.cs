using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Trello.Models.Entities;
using Manatee.Trello;

namespace Apps.Trello.Models.Responses.Card
{
    public class AddAttachmentResponse
    {
        public AttachmentEntity Attachment { get; set; }

        public AddAttachmentResponse()
        {
            Attachment = new AttachmentEntity();
        }

        public AddAttachmentResponse(IAttachment attachment)
        {
            Attachment = new AttachmentEntity(attachment);
        }
    }
}
