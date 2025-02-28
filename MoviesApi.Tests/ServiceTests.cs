using Moq;
using MoviesApi.Models;
using MoviesApi.Repositories;
using MoviesApi.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MoviesApi.Tests
{
    public class MovieServiceTests
    {
        private readonly Mock<IMovieRepository> _mockRepository;
        private readonly MovieService _movieService;

        public MovieServiceTests()
        {
            _mockRepository = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockRepository.Object);
        }

        [Theory]
        [InlineData(9, 3)]  // 9 movies will expect 3 total pages
        [InlineData(10, 4)]  // 10 movies will expect 4 total pages
        public async Task GetMoviesByTitleAsync_ShouldReturnPaginatedMovies_WhenValidRequestIsMade(int totalMovies, int expectedTotalPages)
        {
            // Arrange
            var movieSearchRequest = new MovieSearchRequest
            {
                Title = "Test",
                Limit = totalMovies,  
                PageNumber = 1,// 3 movies per page
                PageSize = 3
            };

            var mockMovies = new List<Movie>();

            for (int i = 1; i <= totalMovies; i++)
            {
                mockMovies.Add(new Movie { Title = $"Test Movie {i}" });
            }

            _mockRepository.Setup(repo => repo.GetMoviesByTitleAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(mockMovies);

            // Act
            var result = await _movieService.GetMoviesByTitleAsync(movieSearchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Movies.Count());
            Assert.Equal(1, result.CurrentPage);
            Assert.Equal(3, result.PageSize); 
            Assert.Equal(expectedTotalPages, result.TotalPages); 
            Assert.Equal(totalMovies, result.TotalMovies);
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_ShouldReturnEmptyMovies_WhenNoMoviesMatchTitle()
        {
            // Arrange
            var movieSearchRequest = new MovieSearchRequest
            {
                Title = "NonExistingTitle",
                Limit = 100,
                PageNumber = 1,
                PageSize = 10
            };

            var mockMovies = new List<Movie>(); // No movies available

            _mockRepository.Setup(repo => repo.GetMoviesByTitleAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(mockMovies);

            // Act
            var result = await _movieService.GetMoviesByTitleAsync(movieSearchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Movies); 
            Assert.Equal(0, result.TotalPages); 
            Assert.Equal(0, result.TotalMovies); 
        }
        
        [Fact]
        public async Task GetMoviesByTitleAsync_ShouldHandleEmptyResultForMovies()
        {
            // Arrange
            var movieSearchRequest = new MovieSearchRequest
            {
                Title = "AnyTitle",
                Limit = 0,
                PageNumber = 1,
                PageSize = 10
            };

            var mockMovies = new List<Movie>();

            _mockRepository.Setup(repo => repo.GetMoviesByTitleAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(mockMovies);

            // Act
            var result = await _movieService.GetMoviesByTitleAsync(movieSearchRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Movies);
            Assert.Equal(0, result.TotalMovies); 
        }
    }
}
