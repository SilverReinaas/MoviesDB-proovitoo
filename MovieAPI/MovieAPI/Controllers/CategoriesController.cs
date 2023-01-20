using Microsoft.AspNetCore.Mvc;
using MovieAPI.Core;
using MovieAPI.Infrastructure.Services;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IMovieService movieService;

        public CategoriesController(IMovieService _movieService)
        {
            movieService = _movieService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<CategoryModel> Get()
        {
            var categories = movieService.GetCategories();
            var result = new List<CategoryModel>();
            foreach (var category  in categories)
            {
                result.Add(CategoryModel.CategoryToModel(category));
            }
            return result;
        }
    }
}
