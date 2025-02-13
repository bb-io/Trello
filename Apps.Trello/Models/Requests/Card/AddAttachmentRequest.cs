using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Trello.Models.Requests.Card
{
    public class AddAttachmentRequest : CardRequest
    {
        [Display("Attachment name")]
        public string? Name { get; set; }

        [Display("URL")]
        public string? Url { get; set; }

        [Display("File")]
        public FileReference? File { get; set; }

        [Display("Mime type")]
        public string? MimeType { get; set; }

        [Display("Set as cover?")]
        public bool? SetCover { get; set; }
    }
}
