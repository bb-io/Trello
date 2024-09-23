using Apps.Trello.Models.Requests.Board;
using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello.Models.Requests.Card
{
    public class FindCardRequest : BoardRequest
    {
        [Display("Card name")]
        public string? Name { get; set; }

        [Display("Card url")]
        public string? Url { get; set; }
    }
}
