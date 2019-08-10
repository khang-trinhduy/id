using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class IdentityCardEntityTypeConfiguration : IEntityTypeConfiguration<IdentityCard>
    {
        public void Configure(EntityTypeBuilder<IdentityCard> builder)
        {
            builder.ToTable("Identity");

            builder.Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo("identity_hilo")
                .IsRequired(true);
            
            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<LocalIdentityCard>("Local")
                .HasValue<Passport>("Passport");
        }
    }
}