using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class OneBedroomApartmentEntityTypeConfiguration : IEntityTypeConfiguration<OneBedroomApartment>
    {
        public void Configure(EntityTypeBuilder<OneBedroomApartment> builder)
        {
        }
    }
}