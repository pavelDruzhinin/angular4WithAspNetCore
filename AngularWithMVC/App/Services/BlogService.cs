using System.Collections.Generic;
using System.Linq;
using AngularWithMVC.App.Dto;
using AngularWithMVC.Data;
using AngularWithMVC.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularWithMVC.App.Services
{
	public class BlogService
	{
		private BlogContext _blogContext;

		public BlogService(BlogContext blogContext)
		{
			_blogContext = blogContext;
		}

		public int Create(BlogPost post)
		{
			var writer = _blogContext.Writers.FirstOrDefault();

			if (writer == null)
			{
				writer = new Writer
				{
					FirstName = "Иван",
					LastName = "Иванов"
				};

				_blogContext.Writers.Add(writer);
				post.Writer = writer;
			}
			else
			{
				post.WriterId = writer.Id;
			}

			_blogContext.BlogPosts.Add(post);
			_blogContext.SaveChanges();

			return post.Id;
		}

		public List<BlogPost> GetBlogPosts(BlogPostFilter filter)
		{
			if (filter.Page == 0)
				filter.Page = 1;

			if (filter.PageSize == 0)
				filter.PageSize = 15;

			var skip = filter.PageSize * (filter.Page - 1);

			return _blogContext.BlogPosts.Include(x => x.Writer).Take(filter.PageSize).Skip(skip).ToList();
		}
	}
}