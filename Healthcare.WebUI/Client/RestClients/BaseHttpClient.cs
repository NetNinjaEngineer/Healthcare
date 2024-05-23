using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Healthcare.WebUI.Client.RestClients;

public abstract class BaseHttpClient
{
    private readonly HttpClient _httpClient;

    public BaseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    protected async Task<T> GetAsync<T>(string requestUri)
    {
        EnsureAuthenticationHeader();
        var response = await _httpClient.GetAsync(requestUri);
        return await DeserializeResponse<T>(response);
    }

    protected async Task<TResponse> PostAsync<TRequest, TResponse>(string requestUri, TRequest data)
    {
        EnsureAuthenticationHeader();
        var json = SerializeToJson(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(requestUri, content);
        return await DeserializeResponse<TResponse>(response);
    }

    protected async Task<TResponse> PutAsync<TRequest, TResponse>(string requestUri, TRequest data)
    {
        EnsureAuthenticationHeader();
        var json = SerializeToJson(data);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync(requestUri, content);
        return await DeserializeResponse<TResponse>(response);
    }

    protected async Task DeleteAsync(string requestUri)
    {
        EnsureAuthenticationHeader();
        var response = await _httpClient.DeleteAsync(requestUri);
        response.EnsureSuccessStatusCode();
    }

    private void EnsureAuthenticationHeader()
    {
        // Add authorization header if required
        // For example, you can retrieve authentication token from a service
        // and add it to the request headers here
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "YourAccessToken");
    }

    private async Task<T> DeserializeResponse<T>(HttpResponseMessage response)
    {
        response.EnsureSuccessStatusCode(); // Throws on non-success status codes
        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    private string SerializeToJson(object data)
    {
        return JsonSerializer.Serialize(data, new JsonSerializerOptions { IgnoreNullValues = true });
    }
}
