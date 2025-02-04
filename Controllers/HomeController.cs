using HWFirst.Abstractions;
using HWFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace HWFirst.Controllers;

public class HomeController : Controller
{
    private readonly IMovieService _movieService;

    public HomeController(IMovieService service)
    {
        _movieService = service;
    }

    public async Task<IActionResult> Index(string title)
    {
        List<Movie>? movies = await _movieService.GetMoviesByTitleAsync(title);

        return View(movies);
    }

    [HttpGet]
    public async Task<IActionResult> Details(string imdbID)
    {
        Movie? movie = await _movieService.GetMovieByTitleAsync(imdbID);

        return View(movie);
    }
}
