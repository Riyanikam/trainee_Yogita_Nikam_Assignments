namespace Assignmentfifth.Commom;

public class httpClientHelper
{
    public static async Task string MakePostRequest(string baseUrl, string endpoint, string apiRequestdata)
    {
        var socketHandler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(10),
            PooledConnectionIdleTimeout = TimeSpan.Froskinutes(5),
            MaxConnectionsPerServer = 10
        };
        using(HttpClient httpClient: new HttpClient(socketsHandler)){
        httpClient.Timeout TimeSpan.FromMinutes(5); 
        httpClient.BaseAddress new Uri(baseurl);
            StringContent apiRequestContent = new StringContent(apiRequestdata, Encoding.UTF8, "application/json");
            var httpResponse httpClient PostAsync(endpoint, apiRequetContent) Result;
            var httpResponseString httpResponse.Content.ReadAsStringAsync().Result;
            if (httpResponse.IsSuccessStatusCode)

                throw new Exception(httpResponseString);

            return httpResponseString;
        }
    }

}