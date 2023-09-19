using Apps.Trello.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Trello.Connections;

public class ConnectionDefinition : IConnectionDefinition
{
    public IEnumerable<ConnectionPropertyGroup> ConnectionPropertyGroups => new List<ConnectionPropertyGroup>
    {
        new()
        {
            Name = "Developer API key",
            AuthenticationType = ConnectionAuthenticationType.Undefined,
            ConnectionUsage = ConnectionUsage.Actions,
            ConnectionProperties = new List<ConnectionProperty>
            {
                new(CredsNames.ApiKey) { DisplayName = "API key" },
                new(CredsNames.UserToken) { DisplayName = "User token" }
            }
        }
    };

    public IEnumerable<AuthenticationCredentialsProvider> CreateAuthorizationCredentialsProviders(
        Dictionary<string, string> values)
    {
        var apiKey = values.First(v => v.Key == CredsNames.ApiKey);
        yield return new(
            AuthenticationCredentialsRequestLocation.None,
            apiKey.Key,
            apiKey.Value
        );

        var userToken = values.First(v => v.Key == CredsNames.UserToken);
        yield return new(
            AuthenticationCredentialsRequestLocation.None,
            userToken.Key,
            userToken.Value
        );
    }
}