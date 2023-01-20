using MovieAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }        
        public int Rating { get; set; }

        public static MovieModel MovieToModel(Movie movie, Category category)
        {
            var result = new MovieModel();
            result.Id = movie.Id;
            result.Title = movie.Title;
            result.Year = movie.Year;
            result.Rating = movie.Rating;
            result.Category = category?.Name ?? "";
            return result;
        }
    }
}
