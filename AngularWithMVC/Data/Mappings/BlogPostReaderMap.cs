using AngularWithMVC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWithMVC.Data.Mappings
{
    public class BlogPostReaderMap : IEntityTypeConfiguration<BlogPostRead>
    {
        public void Configure(EntityTypeBuilder<BlogPostRead> builder)
        {
            builder.HasKey(x => new { x.BlogPostId, x.ReaderId });
            builder.HasOne(x => x.BlogPost);
            builder.HasOne(x => x.Reader);
        }
    }
}