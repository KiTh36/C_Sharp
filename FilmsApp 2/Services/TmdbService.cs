using System.Net.Http.Headers;
using System.Text.Json;

using FilmsApp.Models;

namespace FilmsApp.Services;

public class TmdbService
{
    private const string BaseUrl = "https://api.themoviedb.org/3/";

    private readonly HttpClient _httpClient;

    public TmdbService(string accessToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(BaseUrl)
        };

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", accessToken);

        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Movie>> SearchMoviesAsync(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return new List<Movie>();

        string encodedQuery = Uri.EscapeDataString(query);

        string url = $"search/movie?query={encodedQuery}&language=en-US&page=1";

        HttpResponseMessage response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();

        SearchResponse? result = JsonSerializer.Deserialize<SearchResponse>(
            json,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            });

        return result?.Results ?? new List<Movie>();
    }

    private class SearchResponse
    {
        public int Page { get; set; }

        public List<Movie> Results { get; set; } = new();

        public int TotalPages { get; set; }

        public int TotalResults { get; set; }
    }
}