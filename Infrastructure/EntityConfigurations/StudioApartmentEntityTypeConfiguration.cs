using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity_API.Infrastructure.EntityConfigurations
{
    class StudioApartmentEntityTypeConfiguration : IEntityTypeConfiguration<StudioApartment>
    {
        public void Configure(EntityTypeBuilder<StudioApartment> builder)
        {
        }
    }
}