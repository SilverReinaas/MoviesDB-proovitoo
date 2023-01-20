using MovieAPI.Core;
using System.Collections.Generic;

namespace MovieAPI.Infrastructure.Repositories
{
    public interface IMovieRepository
    {
        public List<Movie> GetMovies();
        public Movie GetMovieById(int id);
        public List<Category> GetCategories();
        public Category GetCategoryById(int id);        

    }
}
