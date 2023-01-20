using MovieAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class MovieDetailsModel
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }

        public static MovieDetailsModel MovieToDetailsModel(Movie movie)
        {
            var result = new MovieDetailsModel();
            result.Title = movie.Title;
            result.Year = movie.Year;
            result.Rating = movie.Rating;
            result.Description = movie.Description;
            return result;
        }
    }
}
