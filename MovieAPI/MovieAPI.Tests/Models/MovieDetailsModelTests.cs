using MovieAPI.Core;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieAPI.Tests.Models
{
    public class MovieDetailsModelTests
    {
        private Movie movie;
        private MovieDetailsModel movieDetailsModel;

        public MovieDetailsModelTests()
        {
            this.movie = new Movie
            {
                Id = 1,
                CategoryId = 2,
                Description = "description",
                Title = "title",
                Rating = 5,
                Year = 1900
            };

            this.movieDetailsModel = MovieDetailsModel.MovieToDetailsModel(movie);
        }

        [Fact]
        public void MovieDetailsModel_SetsCorrectTitle()
        {
            Assert.Equal("title", movieDetailsModel.Title);
        }

        [Fact]
        public void MovieDetailsModel_SetsCorrectDescription()
        {
            Assert.Equal("description", movieDetailsModel.Description);
        }

        [Fact]
        public void MovieDetailsModel_SetsCorrectRating()
        {
            Assert.Equal(5, movieDetailsModel.Rating);
        }

        [Fact]
        public void MovieDetailsModel_SetsCorrectYear()
        {
            Assert.Equal(1900, movieDetailsModel.Year);
        }
    }
}
