using System.ComponentModel.DataAnnotations;

namespace BrokenBlogApi.Models
{
    /// <summary>
    /// Represents a blog post in the system
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// The unique identifier for the blog post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The title of the blog post
        /// </summary>
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// A brief description of the blog post
        /// </summary>
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters")]
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// The main content of the blog post
        /// </summary>
        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;
    }
}
