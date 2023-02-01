using Moq;
using MovieAPI.Core;
using MovieAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI.Tests.Mocks
{
    internal class MockIMovieRepository
    {
        public static Mock<IMovieRepository> GetMock()
        {
            var mock = new Mock<IMovieRepository>();
            var movies = new List<Movie>
            {
                new Movie{ Id = 1, Title = "The Shawshank Redemption", Rating = 9, Year = 1994, CategoryId = 1, Description =  "Two imprisoned men bond over a number of years, finding solace and eventual redemption through acts of common decency."},
                new Movie{ Id = 2, Title = "The Godfather", Rating = 9, Year = 1972, CategoryId = 2, Description = "The aging patriarch of an organized crime dynasty in postwar New York City transfers control of his clandestine empire to his reluctant youngest son." },
                new Movie{ Id = 3, Title = "The Dark knight", Rating = 6, Year = 2008, CategoryId = 3, Description = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                new Movie{ Id = 4, Title = "The Godfather: Part II", Rating = 7, Year = 1974, CategoryId = 2, Description = "The early life and career of Vito Corleone in 1920s New York City is portrayed, while his son, Michael, expands and tightens his grip on the family crime syndicate." },
                new Movie{ Id = 5, Title = "12 Angry Men", Rating = 8, Year = 1957, CategoryId = 2, Description = "The jury in a New York City murder trial is frustrated by a single member whose skeptical caution forces them to more carefully consider the evidence before jumping to a hasty verdict." },
                new Movie{ Id = 6, Title = "Schindler's List", Rating = 8, Year = 1993, CategoryId = 4, Description = "In German-occupied Poland during World War II, industrialist Oskar Schindler gradually becomes concerned for his Jewish workforce after witnessing their persecution by the Nazis." },
                new Movie{ Id = 7, Title = "Pulp Fiction", Rating = 7, Year = 1994, CategoryId = 2, Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption." },
                new Movie{ Id = 8, Title = "Forrest Gump", Rating = 6, Year = 1994, CategoryId = 1, Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal and other historical events unfold from the perspective of an Alabama man with an IQ of 75, whose only desire is to be reunited with his childhood sweetheart." },
                new Movie{ Id = 9, Title = "Fight club", Rating = 10, Year = 1999, CategoryId = 1, Description = "An insomniac office worker and a devil-may-care soap maker form an underground fight club that evolves into much more." }
            };

            var categories = new List<Category>
            {
                new Category{ Id = 1, Name = "Drama" },
                new Category{ Id = 2, Name = "Crime" },
                new Category{ Id = 3, Name = "Action" },
                new Category{ Id = 4, Name = "History" }
            };

            mock.Setup(m => m.GetMovieById(It.IsAny<int>())).Returns((int id) => movies.FirstOrDefault(m => m.Id == id));
            mock.Setup(m => m.GetMovies()).Returns(movies);
            mock.Setup(m => m.GetCategoryById(It.IsAny<int>())).Returns((int id) => categories.FirstOrDefault(c => c.Id == id));
            mock.Setup(m => m.GetCategories()).Returns(categories);

            return mock;
        }
    }
}
