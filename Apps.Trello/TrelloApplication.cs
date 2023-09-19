using Blackbird.Applications.Sdk.Common;

namespace Apps.Trello;

public class TrelloApplication : IApplication
{
    public string Name
    {
        get => "Trello";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}