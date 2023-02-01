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
    public class CategoryModelTests
    {
        [Theory]
        [InlineData("test", "test")]
        [InlineData(null, "")]
        public void CategoryToModel_SetsCorrectProperties(string categoryName, string expected)
        {
            //Arrange
            var category = new Category { Id = 1, Name = categoryName };

            //Act
            var categoryModel = CategoryModel.CategoryToModel(category);

            //Assert
            Assert.Equal(expected, categoryModel.Name);
        }
    }
}
