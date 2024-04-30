using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Trello.DataSourceHandlers.Static;

public class ListPositionDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["top"] = "Top",
            ["bottom"] = "Bottom",
        };
    }
}