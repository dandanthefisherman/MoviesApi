using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesByTitleAsync(string title,int limit);
    }
}