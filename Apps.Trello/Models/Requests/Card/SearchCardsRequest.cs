using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card
{
    public class SearchCardsRequest : BoardRequest
    {
        [Display("Card name")]
        public string? Name { get; set; }

        [Display("Description contains")]
        public string? Description { get; set; }

        [Display("Created date from")]
        public DateTime? CreatedDateFrom { get; set; }

        [Display("Created date to")]
        public DateTime? CreatedDateTo { get; set; }

        [Display("Last activity date from")]
        public DateTime? ActivityDateFrom { get; set; }

        [Display("Last activity date to")]
        public DateTime? ActivityDateTo { get; set; }

    }
}
