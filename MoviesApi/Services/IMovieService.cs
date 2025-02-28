using MoviesApi.Models;

namespace MoviesApi.Services
{
    public interface IMovieService
    {
        Task<MovieSearchResponse> GetMoviesByTitleAsync(MovieSearchRequest movieSearchRequest);
    }
}