using Moq;
using MovieAPI.Core;
using MovieAPI.Infrastructure.Repositories;
using MovieAPI.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieAPI.Tests.Infrastructure.Services
{
    public class MovieServiceTests
    {
        private IMovieService movieService;

        public MovieServiceTests()
        {
            var movieRepositoryMock = Mocks.MockIMovieRepository.GetMock();
            this.movieService = new MovieService(movieRepositoryMock.Object);
        }

        [Fact]
        public void GetMovies_AllMoviesReturn()
        {
            var result = movieService.GetMovies();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.IsAssignableFrom<IEnumerable<Movie>>(result);
        }
                
        [Theory]
        [InlineData(1, "The Shawshank Redemption")]
        [InlineData(5, "12 Angry Men")]        
        public void GetMovieById_ReturnsCorrectMovie(int id, string expectedTitle)
        {
            var movie = movieService.GetMovieById(id);
            Assert.NotNull(movie);
            Assert.Equal(movie.Title, expectedTitle);
        }

        [Fact]
        public void GetMovieById_ReturnsNullWhenNotFound()
        {
            var movie = movieService.GetMovieById(999);
            Assert.Null(movie);
        }
    }
}
