using Microsoft.EntityFrameworkCore;
using Identity_API.Infrastructure.EntityConfigurations;
using Contact.Class.Apartments;
using Contact.Class;

namespace Identity_API.Data
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {

        }
        public DbSet<Contact.Class.Contact> Contact { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) => builder.UseLazyLoadingProxies();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductEntityTypeConfiguration());

            builder.ApplyConfiguration(new IdentityCardEntityTypeConfiguration());

            // builder.ApplyConfiguration(new OneBedroomApartmentEntityTypeConfiguration());

            // builder.ApplyConfiguration(new PassportEntityTypeConfiguration());

            // builder.ApplyConfiguration(new StudioApartmentEntityTypeConfiguration());

            // builder.ApplyConfiguration(new TwoBedroomApartmentEntityTypeConfiguration());

            // builder.ApplyConfiguration(new TwoBedroomPlusApartmentEntityTypeConfiguration());

            // builder.ApplyConfiguration(new ThreeBedroomPlusApartmentEntityTypeConfiguration());

            builder.ApplyConfiguration(new LocalCardEntityTypeConfiguration());

            builder.ApplyConfiguration(new ContactEntityTypeConfiguration());

            builder.Entity<OneBedroomApartment>()
                .HasBaseType<Product>();

            builder.Entity<StudioApartment>()
                .HasBaseType<Product>();

            builder.Entity<TwoBedroomPlusApartment>()
                .HasBaseType<Product>();

            builder.Entity<TwoBedroomApartment>()
                .HasBaseType<Product>();

            builder.Entity<ThreeBedroomApartment>()
                .HasBaseType<Product>();

            builder.Entity<LocalIdentityCard>()
                .HasBaseType<IdentityCard>();
            
            builder.Entity<Passport>()
                .HasBaseType<IdentityCard>();
            
        }
    }
}