using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class TwoBedroomApartmentEntityTypeConfiguration : IEntityTypeConfiguration<TwoBedroomApartment>
    {
        public void Configure(EntityTypeBuilder<TwoBedroomApartment> builder)
        {

        }
    }
}