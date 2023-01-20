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
        private readonly IMovieRepository movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            this.movieRepository = movieRepository;
        }
        public List<Movie> GetMovies()
        {
            return movieRepository.GetMovies();
        }

        public Movie GetMovieById(int id)
        {
            return movieRepository.GetMovieById(id);
        }

        public List<Category> GetCategories()
        {
            return movieRepository.GetCategories();
        }
    }
}
