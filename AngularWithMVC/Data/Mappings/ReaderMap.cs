using AngularWithMVC.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AngularWithMVC.Data.Mappings
{
    public class ReaderMap : IEntityTypeConfiguration<Reader>
    {
        public void Configure(EntityTypeBuilder<Reader> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.BlogPostReads);
        }
    }
}