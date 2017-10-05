using AngularWithMVC.Data.Mappings;
using AngularWithMVC.Domain;
using Microsoft.EntityFrameworkCore;

namespace AngularWithMVC.Data
{
	public class BlogContext : DbContext
	{
		public DbSet<BlogPost> BlogPosts { get; set; }
		public DbSet<BlogPostRead> BlogPostReads { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<Reader> Readers { get; set; }

		public BlogContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new BlogPostMap());
			modelBuilder.ApplyConfiguration(new WriterMap());
			modelBuilder.ApplyConfiguration(new ReaderMap());
			modelBuilder.ApplyConfiguration(new BlogPostReaderMap());

			base.OnModelCreating(modelBuilder);
		}
	}
}
