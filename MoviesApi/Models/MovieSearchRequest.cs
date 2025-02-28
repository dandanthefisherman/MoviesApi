namespace MoviesApi.Models;

public class MovieSearchRequest
{
    public string Title{ get; set; }
    public int Limit{ get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}