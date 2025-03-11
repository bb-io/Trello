using Apps.Trello.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Trello.Webhooks.Models
{
    public class CardOptionFilter
    {
        [Display("Board ID")]
        [DataSource(typeof(BoardDataHandler))]
        public string? BoardId { get; set; }

        [Display("Card ID")]
        [DataSource(typeof(CardOptionDataHandler))]
        public string? CardId { get; set; }

        [Display("Old list ID")]
        [DataSource(typeof(ListOptionDataHandler))]
        public string? OldListId { get; set; }

        [Display("New list ID")]
        [DataSource(typeof(ListOptionDataHandler))]
        public string? NewListId { get; set; }
    }
}
