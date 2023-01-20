﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Infrastructure.Services;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers{   

    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService movieService;

        public MovieController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<MovieModel> Get()
        {
            var movies = movieService.GetMovies();
            var categories = movieService.GetCategories();

            var result = new List<MovieModel>();
            foreach (var movie in movies)
            {
                var category = categories.FirstOrDefault(x => x.Id == movie.CategoryId);
                result.Add(MovieModel.MovieToModel(movie, category));
            }
            return result;
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public ActionResult<MovieDetailsModel> Get(int id)
        {
            var movie = movieService.GetMovieById(id);
            if(movie == null)
            {
                return NotFound();
            }
            return MovieDetailsModel.MovieToDetailsModel(movie);
        }

    }
}
