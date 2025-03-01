using MoviesApi.Models;
using MoviesApi.Repositories;

namespace MoviesApi.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<MovieSearchResponse> GetMoviesByTitleAsync(MovieSearchRequest movieSearchRequest)
        {
            var movies = _repository.GetMoviesByTitleAsync(movieSearchRequest.Title,movieSearchRequest.Limit).Result;
            
            var skipCount = (movieSearchRequest.PageNumber - 1) * movieSearchRequest.PageSize;

            var paginatedMovies = movies
                .Skip(skipCount)
                .Take(movieSearchRequest.PageSize);
            
             var totalPages = (int)Math.Ceiling(movies.Count() / (double)movieSearchRequest.PageSize);
            
             var response = new MovieSearchResponse
             {
                 TotalMovies = movies.Count(),
                 TotalPages = totalPages,
                 CurrentPage = movieSearchRequest.PageNumber,
                 PageSize = paginatedMovies.Count(),
                 Movies = paginatedMovies
             };

            return response;
        }
    }
    
}

