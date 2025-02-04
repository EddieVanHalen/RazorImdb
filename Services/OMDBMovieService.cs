using HWFirst.Abstractions;
using HWFirst.Models;
using HWFirst.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace HWFirst.Services;

public class OMDBMovieService : IMovieService
{
    private const string _DOMAIN = @"http://www.omdbapi.com/";

    private readonly HttpClient _httpClient;

    private readonly string _apiKey;

    public OMDBMovieService(IOptions<ApiOptions> options)
    {
        _httpClient = new HttpClient();
        _apiKey = options.Value.ApiKey;
    }

    public async Task<Movie?> GetMovieByTitleAsync(string title)
    {
        string result = await _httpClient.GetStringAsync($"{_DOMAIN}?i={title}&apikey={_apiKey}");

        Movie? movie = JsonConvert.DeserializeObject<Movie>(result);

        return movie;
    }

    public async Task<List<Movie>?> GetMoviesByTitleAsync(string title)
    {
        string result = await _httpClient.GetStringAsync($"{_DOMAIN}?s={title}&apikey={_apiKey}");

        SearchResult? searchResult = JsonConvert.DeserializeObject<SearchResult>(result);

        return searchResult?.Search;
    }
}
