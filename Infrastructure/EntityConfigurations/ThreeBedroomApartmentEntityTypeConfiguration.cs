using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class ThreeBedroomPlusApartmentEntityTypeConfiguration : IEntityTypeConfiguration<ThreeBedroomApartment>
    {
        public void Configure(EntityTypeBuilder<ThreeBedroomApartment> builder)
        {

        }
    }
}