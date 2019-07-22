using System.Collections.Generic;
using System.Linq;
using MakingSense.DataContext;
using MakingSense.Model;
using Microsoft.AspNetCore.Mvc;

namespace MakingSense.Blog.Controllers
{
    [ApiController]
    public class PostController : Controller
    {

        ApplicationDbContext _context;
        public PostController(ApplicationDbContext context)
        {
            if (context != null)
                _context = context;
        }

        [HttpGet("api/Post/Get/")]
        public List<Post> Get()
        {

            return _context.Posts.ToList();
        }

        [HttpGet("api/Post/Get/{id}")]
        public Post Get(int id)
        {
            return _context.Posts.First(x => x.Id.Equals(id)); 
        }

        [HttpGet("/api/Post/PostByUser/{userId}")]
        public List<Post> PostByUser(int userId)
        {
            return _context.Posts.Where(x => x.UserId == userId).ToList();
        }

        [HttpPost("/api/Post/Post/")]
        public void Post([FromBody] Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("/api/Post/Delete/{id}")]
        public void Delete(int id)
        {
            Post _post = (Post)_context.Posts.Where(x => x.Id == id);
            _post.Deleted = true;
            _context.SaveChanges();
        }
    }
}
