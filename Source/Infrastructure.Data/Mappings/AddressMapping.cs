using System.Data.Entity.ModelConfiguration;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Mappings
{

    class AddressMapping : EntityTypeConfiguration<Address> {

        public AddressMapping() {

            HasKey(p => p.AddressId);

            Property(p => p.Country).IsRequired();
            Property(p => p.State).IsRequired();
            Property(p => p.City).IsRequired();
            Property(p => p.District).IsRequired();
            Property(p => p.Number).IsOptional();
            Property(p => p.Complement).IsOptional();
            Property(p => p.ZipCode).IsRequired();

            HasRequired(p => p.Person).WithMany(p => p.Addresses).HasForeignKey(p => p.PersonId);
        }
    }
}
