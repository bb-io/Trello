using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using RestSharp;

namespace Apps.Trello;

public static class WebhookLogger
{
    private const string WebhookLoggerUrl = "https://webhook.site/bd5fcf4d-336e-4f09-b256-84718243d7f0";
    
    public static async Task LogAsync<T>(T obj) where T : class
    {
        var client = new RestClient(WebhookLoggerUrl);
        var restRequest = new RestRequest(string.Empty, Method.Post)
            .WithJsonBody(obj);
        
        await client.ExecuteAsync(restRequest);
    }
    
    
    public static async Task LogAsync(Exception ex)
    {
        await LogAsync(new
        {
            Exception = ex.Message,
            ex.StackTrace,
            ExceptionType = ex.GetType().Name
        });
    }
}