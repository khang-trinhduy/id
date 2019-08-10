using Contact.Class;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact.Class.Contact>
    {
        public void Configure(EntityTypeBuilder<Contact.Class.Contact> builder)
        {
            builder.ToTable("Contact");

            builder.Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo("contact_hilo")
                .IsRequired();

            builder.Property(e => e.FullName)
                .IsRequired(true);

            builder.Property(e => e.Phone)
                .IsRequired(true);

            builder.HasOne(e => e.Identity)
                .WithOne();

            builder.HasMany<Product>("Product")
                .WithOne()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(e => e.Email)
                .IsRequired(false);

            builder.HasOne(e => e.Identity)
                .WithOne(e => e.Contact)
                .HasForeignKey<IdentityCard>(e => e.ContactId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}