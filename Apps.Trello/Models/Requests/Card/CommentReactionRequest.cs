using Apps.Trello.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Manatee.Trello;

namespace Apps.Trello.Models.Requests.Card
{
    public class CommentReactionRequest : CardRequest
    {
        [Display("Text comment")]
        public string textComment { get; set; }

        [StaticDataSource(typeof(EmojiDataHandler))]
        public string Reaction { get; set; }
    }
}
