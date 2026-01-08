using BlazorTest.Models;
using System.Net.Http.Json;

namespace BlazorTest.Services;

public class TurnstileService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _config;

    public TurnstileService(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<bool> IsUserHuman(string token)
    {
        if (string.IsNullOrEmpty(token)) return false;

        var secret = _config["CloudflareTurnstile:SecretKey"];
        
        var postData = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("secret", secret!),
            new KeyValuePair<string, string>("response", token)
        });

        try 
        {
            var response = await _httpClient.PostAsync("https://challenges.cloudflare.com/turnstile/v0/siteverify", postData);
            var result = await response.Content.ReadFromJsonAsync<TurnstileResponse>();
            return result?.Success ?? false;
        }
        catch
        {
            return false;
        }
    }
}