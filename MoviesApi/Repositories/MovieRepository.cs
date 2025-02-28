using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MoviesDbContext _context;

        public MovieRepository(MoviesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _context.Movies.ToListAsync();
        }
        
        public async Task<IEnumerable<Movie>> GetMoviesByTitleAsync(string title,int limit)
        {
            var movies = await _context.Movies
                .Where(m => m.Title.ToLower().Contains(title.ToLower())) 
                .Take(limit)
                .ToListAsync();
            
            return movies;
           

        }
    }
}