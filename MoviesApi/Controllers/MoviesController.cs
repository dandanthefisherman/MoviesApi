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
            var errors = new List<string>();

            if (movieSearchRequest.Limit <= 0)
              errors.Add("Limit must be greater than zero.");
            if (movieSearchRequest.PageNumber <= 0)
              errors.Add("Page number must be greater than zero.");
            if (movieSearchRequest.PageSize <= 0)
              errors.Add("Page size must be greater than zero.");

            if (errors.Any())
             return BadRequest(string.Join(" ", errors));

            
            // Perform a case-insensitive partial search on the title and limit the results
           
            var moviesSearchResponse = await _service.GetMoviesByTitleAsync(movieSearchRequest);
            
            if (!moviesSearchResponse.Movies.Any())
            {
                return NotFound("No movies found matching your search.");
            }
            
            var paginationMetadata = new
            {
                totalMovies = moviesSearchResponse.TotalMovies,
                totalPages = moviesSearchResponse.TotalPages,
                currentPage = moviesSearchResponse.CurrentPage,
                pageSize = moviesSearchResponse.PageSize
            };

            return Ok(new {moviesSearchResponse.Movies, paginationMetadata });
        }
        
    }
}