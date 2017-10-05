using AngularWithMVC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWithMVC.Data.Mappings
{
    public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);
	        builder.HasOne(x => x.Writer);
			//.WithMany(x => x.BlogPosts).HasForeignKey(x => x.WriterId);
            builder.HasMany(x => x.BlogPostReads);
        }
    }
}