using Contact.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class LocalCardEntityTypeConfiguration : IEntityTypeConfiguration<LocalIdentityCard>
    {
        public void Configure(EntityTypeBuilder<LocalIdentityCard> builder)
        {
            builder.Property(e => e.Number)
                .IsRequired(true);
                
            builder.Property(e => e.AuthorizedDate)
                .IsRequired(true);

            builder.Property(e => e.AuthorizedBy)
                .IsRequired(true);

        }
    }
}