using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class TwoBedroomPlusApartmentEntityTypeConfiguration : IEntityTypeConfiguration<TwoBedroomPlusApartment>
    {
        public void Configure(EntityTypeBuilder<TwoBedroomPlusApartment> builder)
        {

        }
    }
}