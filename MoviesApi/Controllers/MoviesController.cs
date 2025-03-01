using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] MovieSearchRequest movieSearchRequest)
        {
            var validationResult = ValidateSearchRequest(movieSearchRequest);
            if (validationResult != null)
                return validationResult;

            var moviesSearchResponse = await _service.GetMoviesByTitleAsync(movieSearchRequest);

            if (!moviesSearchResponse.Movies.Any())
                return NotFound("No movies found matching your search.");

            var paginationMetadata = new
            {
                moviesSearchResponse.TotalMovies,
                moviesSearchResponse.TotalPages,
                moviesSearchResponse.CurrentPage,
                moviesSearchResponse.PageSize
            };

            return Ok(new { moviesSearchResponse.Movies, paginationMetadata });
        }

        private IActionResult? ValidateSearchRequest(MovieSearchRequest request)
        {
            var errors = new List<string>();

            if (request.Limit <= 0) errors.Add("Limit must be greater than zero.");
            if (request.PageNumber <= 0) errors.Add("Page number must be greater than zero.");
            if (request.PageSize <= 0) errors.Add("Page size must be greater than zero.");

            return errors.Any() ? BadRequest(string.Join(" ", errors)) : null;
        }
    }
}
