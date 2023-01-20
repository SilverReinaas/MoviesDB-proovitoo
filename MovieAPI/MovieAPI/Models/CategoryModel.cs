using MovieAPI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
    public class CategoryModel
    {
        public string Name { get; set; }

        public static CategoryModel CategoryToModel(Category category)
        {
            return new CategoryModel() { Name = category.Name };
        }
    }
}
