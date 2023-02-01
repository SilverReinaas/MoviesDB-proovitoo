using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MovieAPI.Controllers;
using MovieAPI.Core;
using MovieAPI.Infrastructure.Services;
using MovieAPI.Models;
using MovieAPI.Tests.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieAPI.Tests.Controllers
{
    public class MovieControllerTests
    {
        private MovieController movieController;

        public MovieControllerTests()
        {
            var movieRepositoryMock = Mocks.MockIMovieRepository.GetMock();
            var movieService = new MovieService(movieRepositoryMock.Object);
            movieController = new MovieController(movieService);
        }

        [Fact]
        public void Get_AllMoviesReturn()
        {
            var result = this.movieController.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<IEnumerable<MovieModel>>(result);
        }

        [Theory]
        [InlineData(1, "The Shawshank Redemption")]
        [InlineData(9, "Fight club")]
        public void Get_ReturnsCorrectMovieById(int id, string expectedTitle)
        {
            var result = this.movieController.Get(id) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.IsAssignableFrom<MovieDetailsModel>(result.Value);
            Assert.NotNull(result.Value as MovieDetailsModel);
            Assert.Equal(expectedTitle, (result.Value as MovieDetailsModel).Title);
        }

        [Fact]
        public void Get_ReturnsNotFoundByWrongId()
        {
            var result = this.movieController.Get(99) as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result.StatusCode);
        }
    }
}
