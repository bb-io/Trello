using Apps.Trello.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.Trello.Api;

public class TrelloRestRequest(string resource, Method method, IEnumerable<AuthenticationCredentialsProvider> creds)
    : BlackBirdRestRequest(resource, method, creds)
{
    protected override void AddAuth(IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var authenticationCredentialsProviders = creds as AuthenticationCredentialsProvider[] ?? creds.ToArray();
        
        var apiKey = authenticationCredentialsProviders.Get(CredsNames.ApiKey).Value;
        var userToken = authenticationCredentialsProviders.Get(CredsNames.UserToken).Value;
        
        this.AddParameter("key", apiKey, ParameterType.QueryString);
        this.AddParameter("token", userToken, ParameterType.QueryString);
    }
}