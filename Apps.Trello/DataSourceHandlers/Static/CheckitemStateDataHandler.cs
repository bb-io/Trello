using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Trello.DataSourceHandlers.Static
{
    public class CheckitemStateDataHandler : IStaticDataSourceHandler
    {
        public Dictionary<string, string> GetData()
        {
            return new()
            {
                ["Complete"] = "Complete",
                ["Incomplete"] = "Incomplete",
            };
        }
    }
}
