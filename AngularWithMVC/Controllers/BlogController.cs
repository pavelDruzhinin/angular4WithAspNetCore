using System.Collections.Generic;
using AngularWithMVC.App.Dto;
using AngularWithMVC.App.Services;
using AngularWithMVC.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithMVC.Controllers
{
    [Route("api")]
    public class BlogController : Controller
    {
        private BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpPost]
        [Route("blogs")]
        public List<BlogPost> GetBlogPosts([FromBody]BlogPostFilter filter)
        {
            return _blogService.GetBlogPosts(filter);
        }

        [HttpPost]
        [Route("blog")]
        public int Create([FromBody]BlogPost blog)
        {
            return _blogService.Create(blog);
        }
    }
}
