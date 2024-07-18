using Apps.Trello.Constants;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Manatee.Trello;

namespace Apps.Trello.Invocables;

public class TrelloInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();
    
    protected TrelloFactory Client { get; }
    
    protected TrelloInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
        
        TrelloAuthorization.Default.AppKey = Creds.Get(CredsNames.ApiKey).Value;
        TrelloAuthorization.Default.UserToken = Creds.Get(CredsNames.UserToken).Value;
    }
}