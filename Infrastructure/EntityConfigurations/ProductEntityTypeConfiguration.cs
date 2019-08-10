using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Contact.Class.Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(e => e.Id)
                .ForSqlServerUseSequenceHiLo("product_hilo")
                .IsRequired(true);

            builder.HasDiscriminator<string>("Discriminator")
                .HasValue<OneBedroomApartment>("1br")
                .HasValue<StudioApartment>("studio")
                .HasValue<TwoBedroomApartment>("2br")
                .HasValue<TwoBedroomPlusApartment>("2br+")
                .HasValue<ThreeBedroomApartment>("3br");
        }
    }
}