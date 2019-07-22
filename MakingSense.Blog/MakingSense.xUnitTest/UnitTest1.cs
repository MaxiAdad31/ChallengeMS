using MakingSense.Blog.Controllers;
using MakingSense.DataContext;
using MakingSense.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MakingSense.xUnitTest
{
    public class UnitTest1
    {
        public PostController _postController = null;
        public ApplicationDbContext AppContext { get; private set; }


        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                     .UseInMemoryDatabase("Blogging")
                     .Options;
            AppContext = new ApplicationDbContext(options);

            _postController = new PostController(AppContext);

            SeedTestData();
        }

        #region SeedDataMethods
        private void SeedTestData()
        {

            if (AppContext.Users.Any())
            {
                return;
            }

            AppContext.Users.AddRange(
                    new User
                    {
                        Id = 1,
                        FirstName = "Lionel",
                        LastName = "Messi",
                        Posts = CompleteFirstUserPosts()
                    },
                    new User
                    {
                        Id = 2,
                        FirstName = "Juan Martín",
                        LastName = "Del Potro",
                        Posts = CompleteSecondUserPosts()
                    },
                    new User
                    {
                        Id = 3,
                        FirstName = "Alicia",
                        LastName = "Kiss",
                        Posts = CompleteThirdUserPosts()
                    }
                );
            AppContext.SaveChanges();

        }

        private static List<Post> CompleteFirstUserPosts()
        {
            List<Post> result = new List<Post>();
            result.Add(new Post()
            {
                Id = 1,
                UserId = 1,
                Content = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen."
            });
            result.Add(new Post()
            {
                Id = 2,
                UserId = 1,
                Content = "Lorem Ipsum es simplemente el texto de relleno de las imprentas y archivos de texto. Lorem Ipsum ha sido el texto de relleno estándar de las industrias desde el año 1500, cuando un impresor (N. del T. persona que se dedica a la imprenta) desconocido usó una galería de textos y los mezcló de tal manera que logró hacer un libro de textos especimen."
            });
            return result;
        }
        private static List<Post> CompleteSecondUserPosts()
        {
            List<Post> result = new List<Post>();
            result.Add(new Post()
            {
                Id = 3,
                UserId = 2,
                Content = "Es un hecho establecido hace demasiado tiempo que un lector se distraerá con el contenido del texto de un sitio mientras que mira su diseño. El punto de usar Lorem Ipsum es que tiene una distribución más o menos normal de las letras, al contrario de usar textos como por ejemplo 'Contenido aquí,contenido aquí'."
            });
            result.Add(new Post()
            {
                Id = 4,
                UserId = 2,
                Content = "Muchos paquetes de autoedición y editores de páginas web usan el Lorem Ipsum como su texto por defecto, y al hacer una búsqueda de 'Lorem Ipsum' va a dar por resultado muchos sitios web que usan este texto si se encuentran en estado de desarrollo."
            });
            result.Add(new Post
            {
                Id = 5,
                UserId = 2,
                Content = "Muchas versiones han evolucionado a través de los años, algunas veces por accidente, otras veces a propósito (por ejemplo insertándole humor y cosas por el estilo)."
            });
            return result;
        }
        private static List<Post> CompleteThirdUserPosts()
        {
            List<Post> result = new List<Post>();
            result.Add(new Post()
            {
                Id = 6,
                UserId = 3,
                Content = "Al contrario del pensamiento popular, el texto de Lorem Ipsum no es simplemente texto aleatorio."
            });
            result.Add(new Post()
            {
                Id = 7,
                UserId = 3,
                Content = "Tiene sus raices en una pieza cl´sica de la literatura del Latin, que data del año 45 antes de Cristo, haciendo que este adquiera mas de 2000 años de antiguedad."
            });
            return result;
        }
        #endregion

        [Fact]
        public void GetSuccess()
        {
            var result = _postController.Get();
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetFail()
        {

            //DataGenerator.Initialize(AppContext);
            PostController controller = new PostController(AppContext);
            var result = _postController.Get();
            Assert.Empty(result);
        }
    }
}
