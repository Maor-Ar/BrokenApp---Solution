using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BrokenBlogApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BrokenBlogApi.Controllers
{
    /// <summary>
    /// Controller for managing blog posts
    /// </summary>
    [ApiController]
    [Route("api/posts")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {
        private static readonly List<BlogPost> Posts = new()
        {
            new BlogPost { Id = 1, Title = "First Post", Description = "Description of first post", Content = "Content of first post" },
            new BlogPost { Id = 2, Title = "Second Post", Description = "Description of second post", Content = "Content of second post" }
        };

        /// <summary>
        /// Retrieves all blog posts
        /// </summary>
        /// <returns>A list of all blog posts</returns>
        /// <response code="200">Returns the list of posts</response>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BlogPost>), 200)]
        public ActionResult<IEnumerable<BlogPost>> GetPosts()
        {
            return Ok(Posts);
        }

        /// <summary>
        /// Retrieves a specific blog post by id
        /// </summary>
        /// <param name="id">The ID of the blog post to retrieve</param>
        /// <returns>The requested blog post</returns>
        /// <response code="200">Returns the requested post</response>
        /// <response code="404">If the post is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BlogPost), 200)]
        [ProducesResponseType(404)]
        public ActionResult<BlogPost> GetPost(int id)
        {
            var post = Posts.Find(p => p.Id == id);
            if (post == null)
                return NotFound(new { Message = $"Post with ID {id} not found" });

            return Ok(post);
        }

        /// <summary>
        /// Creates a new blog post
        /// </summary>
        /// <param name="post">The blog post to create</param>
        /// <returns>The created blog post</returns>
        /// <response code="201">Returns the newly created post</response>
        /// <response code="400">If the post data is invalid</response>
        [HttpPost]
        [ProducesResponseType(typeof(BlogPost), 201)]
        [ProducesResponseType(400)]
        public ActionResult<BlogPost> CreatePost([FromBody] BlogPost post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Message = "Invalid post data", Errors = ModelState });
            }

            if (string.IsNullOrWhiteSpace(post.Title) || string.IsNullOrWhiteSpace(post.Content))
            {
                return BadRequest(new { Message = "Title and Content are required" });
            }

            post.Id = Posts.Count > 0 ? Posts.Max(p => p.Id) + 1 : 1;
            Posts.Add(post);

            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }
    }
}
