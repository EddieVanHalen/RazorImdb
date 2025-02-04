using HWFirst.Models;

namespace HWFirst.Abstractions;

public interface IMovieService
{
    Task<List<Movie>?> GetMoviesByTitleAsync(string title);
    Task<Movie?> GetMovieByTitleAsync(string title);
}
