namespace MoviesApi.Models;

public class MovieSearchResponse
{
    public int TotalMovies{ get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    
    public IEnumerable<Movie> Movies { get; set; }
}