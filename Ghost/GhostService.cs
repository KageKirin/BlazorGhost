using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;

namespace Ghost
{
public class GhostService
{
    private HttpClient _httpClient;

    public GhostService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin","*");
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Credentials", "true");
        _httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin,Content-Type");
    }

    public async Task InitializeGhostServiceAsync()
    {
    }

    public string GetBaseUrl()
    {
        return _httpClient.BaseAddress.ToString();
    }

}
}
