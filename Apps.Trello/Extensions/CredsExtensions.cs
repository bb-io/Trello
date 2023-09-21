using Apps.Trello.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Manatee.Trello;

namespace Apps.Trello.Extensions;

public static class CredsExtensions
{
    public static TrelloAuthorization GetAuth(this IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        return new()
        {
            AppKey = creds.Get(CredsNames.ApiKey).Value,
            UserToken = creds.Get(CredsNames.UserToken).Value
        };
    }
}