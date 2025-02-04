using System.Text.Json.Serialization;

namespace HWFirst.Models;

public class SearchResult
{
    public List<Movie>? Search { get; set; }

    [JsonPropertyName("totalResults	")]
    public string? TotalResults { get; set; }

    public string? Response { get; set; }
}
