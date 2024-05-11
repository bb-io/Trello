using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Manatee.Trello;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Trello.Models.Requests.Card
{
    public class CopyCardRequest
    {
        [Display("Card to copy ID")]
        [DataSource(typeof(CardDataHandler))]
        public string CardId { get; set; }

        [Display("Copy Attachments?")]
        public bool? CopyAttachments { get; set; }

        [Display("Copy Checklists?")]
        public bool? CopyChecklists { get; set; } 

        [Display("Copy Comments?")]
        public bool? CopyComments { get; set; }

        [Display("Copy Due?")]
        public bool? CopyDue { get; set; }

        [Display("Copy Labels?")]
        public bool? CopyLabels { get; set; }

        [Display("Copy Members?")]
        public bool? CopyMembers { get; set; }

        [Display("Copy Stickers?")]
        public bool? CopyStickers { get; set; }

        public CardCopyKeepFromSourceOptions GetCopyOptions()
        {
            var Options = new CardCopyKeepFromSourceOptions();

            if (CopyAttachments.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Attachments;
            if (CopyChecklists.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Checklists;
            if (CopyComments.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Comments;
            if (CopyDue.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Due;
            if (CopyLabels.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Labels;
            if (CopyMembers.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Members;
            if (CopyStickers.GetValueOrDefault(false)) Options |= CardCopyKeepFromSourceOptions.Stickers;

            return Options;
            
        }

    }
}
