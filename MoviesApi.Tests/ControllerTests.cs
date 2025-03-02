using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MoviesApi.Controllers;
using MoviesApi.Models;
using MoviesApi.Services;
using Xunit;

namespace MoviesApi.Tests
{
    public class ControllerTests
    {
        private readonly Mock<IMovieService> _mockService;
        private readonly MoviesController _controller;

        public ControllerTests()
        {
            _mockService = new Mock<IMovieService>();
            _controller = new MoviesController(_mockService.Object);
        }

        [Theory]
        [InlineData(0, 1, 5, "Limit must be greater than zero.")]
        [InlineData(10, 0, 5, "Page number must be greater than zero.")]
        [InlineData(10, 1, 0, "Page size must be greater than zero.")]
        [InlineData(0, 0, 0, "Limit must be greater than zero. Page number must be greater than zero. Page size must be greater than zero.")]
        public async Task SearchMovies_ReturnsBadRequest_WhenRequestIsInvalid(int limit, int pageNumber, int pageSize, string expectedErrorMessage)
        {
            // Arrange
            var invalidRequest = new MovieSearchRequest { Limit = limit, PageNumber = pageNumber, PageSize = pageSize };

            // Act
            var result = await _controller.SearchMovies(invalidRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(expectedErrorMessage, badRequestResult.Value.ToString());
        }

        [Fact]
        public async Task SearchMovies_ReturnsNotFound_WhenNoMoviesMatch()
        {
            // Arrange
            var validRequest = new MovieSearchRequest { Limit = 10, PageNumber = 1, PageSize = 5 };
            _mockService.Setup(s => s.GetMoviesByTitleAsync(validRequest))
                        .ReturnsAsync(new MovieSearchResponse { Movies = new List<Movie>(), TotalMovies = 0, TotalPages = 0, CurrentPage = 1, PageSize = 5 });

            // Act
            var result = await _controller.SearchMovies(validRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

        [Fact]
        public async Task SearchMovies_ReturnsOk_WithMoviesAndPagination()
        {
            // Arrange
            var validRequest = new MovieSearchRequest {Limit = 10, PageNumber = 1, PageSize = 5};
            var movies = new List<Movie> {new Movie {Id = 1, Title = "Inception"}};
            var response = new MovieSearchResponse
            {
                Movies = movies,
                TotalMovies = 1,
                TotalPages = 1,
                CurrentPage = 1,
                PageSize = 5
            };

            _mockService.Setup(s => s.GetMoviesByTitleAsync(validRequest))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.SearchMovies(validRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

        }
    }
}
