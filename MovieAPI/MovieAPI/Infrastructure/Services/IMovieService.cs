using MovieAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Infrastructure.Services
{
    public interface IMovieService
    {
        public List<Movie> GetMovies();
        public Movie GetMovieById(int id);
        public List<Category> GetCategories();
    }
}
