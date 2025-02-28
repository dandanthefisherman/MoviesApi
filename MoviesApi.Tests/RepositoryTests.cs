using Moq;
using MoviesApi.Models;
using MoviesApi.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MoviesApi.Tests
{
    public class MovieRepositoryTests
    {
        private readonly Mock<IMovieRepository> _mockMovieRepository;

        public MovieRepositoryTests()
        {
            _mockMovieRepository = new Mock<IMovieRepository>();
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_ShouldReturnIEnumerableOfMovie()
        {
            var mockMovies = new List<Movie>
            {
                new Movie { Title = "Test Movie 1" },
                new Movie { Title = "Test Movie 2" }
            };

            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitleAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(mockMovies);

            var result = await _mockMovieRepository.Object.GetMoviesByTitleAsync("Test", 10);

            Assert.IsAssignableFrom<IEnumerable<Movie>>(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetMoviesByTitleAsync_ShouldReturnEmptyList_WhenNoMoviesMatchTitle()
        {
            var titleFilter = "NonExistentTitle";
            var mockMovies = new List<Movie>();

            _mockMovieRepository.Setup(repo => repo.GetMoviesByTitleAsync(It.IsAny<string>(), It.IsAny<int>()))
                .ReturnsAsync(mockMovies);

            var result = await _mockMovieRepository.Object.GetMoviesByTitleAsync(titleFilter, 10);

            Assert.IsAssignableFrom<IEnumerable<Movie>>(result);
            Assert.Empty(result);
        }
    }
}
    