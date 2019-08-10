using System;
using System.Collections.Generic;
using System.Linq;
using Contact.Class;
using Contact.Class.Apartments;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Identity_API.Data
{
    public static class IdentityDbSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new IdentityDbContext(serviceProvider.GetRequiredService<DbContextOptions<IdentityDbContext>>()))
            {
                if (context.Contact.Any())
                {
                    return;
                }
                context.Contact.AddRange(
                    new Contact.Class.Contact
                    {
                        FullName = "Patrick Shou",
                        Phone = "0789123987",
                        Email = "patrick.shou@gmail.com",
                        Identity = new Passport
                        {
                            Gender = Contact.Enum.Gender.Male,
                            FamiliName = "Patrick",
                            GivenName = "Shou",
                            Number = "17993011233",
                            Type = "D",
                            Nationality = "deutsch",
                            AuthorizedBy = "Germany",
                            AuthorizedDate = DateTime.Parse("12-05-2013", System.Globalization.CultureInfo.InvariantCulture)
                        }
                    },
                    new Contact.Class.Contact
                    {
                        FullName = "Maria Janee",
                        Phone = "04583910",
                        Email = "janee.best@gmail.com",
                        Identity = new Passport
                        {
                            Gender = Contact.Enum.Gender.Female,
                            FamiliName = "Janee",
                            GivenName = "Maria",
                            Number = "2333444111",
                            Type = "D",
                            Nationality = "deutsch",
                            AuthorizedBy = "Germany",
                            AuthorizedDate = DateTime.Parse("04-12-2013", System.Globalization.CultureInfo.InvariantCulture)
                        },
                        Product = new List<Product> {
                            new StudioApartment(1300000, "Studio", "southeast", "nothing", 2, 69)
                        }
                    }
                );

                context.SaveChanges();
            }
        }
    }
}