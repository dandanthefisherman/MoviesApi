using System;

namespace MoviesApi.Models
{
    public class Movie
    {
        public int Id { get; set; } // Primary Key
        
        public DateTime ReleaseDate { get; set; } // Release Date of the movie
        
        public string Title { get; set; } // Title of the movie
        
        public string Overview { get; set; } // Overview or description of the movie
        
        public double Popularity { get; set; } // Popularity score
        
        public int VoteCount { get; set; } // Number of votes the movie has received
        
        public double VoteAverage { get; set; } // Average vote score
        
        public string OriginalLanguage { get; set; } // Original language of the movie
        
        public string Genre { get; set; } // Genre of the movie (could be a comma-separated list or a single genre)
        
        public string PosterUrl { get; set; } // URL to the movie poster
    }
}