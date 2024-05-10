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
        public bool? CopyAttachments { get; set; } = false;

        [Display("Copy Checklists?")]
        public bool? CopyChecklists { get; set; } = false;

        [Display("Copy Comments?")]
        public bool? CopyComments { get; set; } = false;

        [Display("Copy Due?")]
        public bool? CopyDue { get; set; } = false;

        [Display("Copy Labels?")]
        public bool? CopyLabels { get; set; } = false;

        [Display("Copy Members?")]
        public bool? CopyMembers { get; set; } = false;

        [Display("Copy Stickers?")]
        public bool? CopyStickers { get; set; } = false;

        public CardCopyKeepFromSourceOptions GetCopyOptions()
        {
            var Options = new CardCopyKeepFromSourceOptions();

            if ((bool)CopyAttachments) Options |= CardCopyKeepFromSourceOptions.Attachments;
            if ((bool)CopyChecklists) Options |= CardCopyKeepFromSourceOptions.Checklists;
            if ((bool)CopyComments) Options |= CardCopyKeepFromSourceOptions.Comments;
            if ((bool)CopyDue) Options |= CardCopyKeepFromSourceOptions.Due;
            if ((bool)CopyLabels) Options |= CardCopyKeepFromSourceOptions.Labels;
            if ((bool)CopyMembers) Options |= CardCopyKeepFromSourceOptions.Members;
            if ((bool)CopyStickers) Options |= CardCopyKeepFromSourceOptions.Stickers;

            return Options;
            
        }

    }
}
