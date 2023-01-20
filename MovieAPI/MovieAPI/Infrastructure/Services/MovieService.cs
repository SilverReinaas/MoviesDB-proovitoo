using MovieAPI.Core;
using MovieAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        public List<Movie> GetMovies()
        {
            return MovieRepository.GetMovies();
        }

        public Movie GetMovieById(int id)
        {
            return MovieRepository.GetMovieById(id);
        }

        public List<Category> GetCategories()
        {
            return MovieRepository.GetCategories();
        }
    }
}
