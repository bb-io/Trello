using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Trello;

public class TrelloApplication : IApplication, ICategoryProvider
{
    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.ProjectManagementAndProductivity, ApplicationCategory.TaskManagement];
        set { }
    }

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