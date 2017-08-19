using System.Data.Entity.ModelConfiguration;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Mappings
{

    class PersonMapping : EntityTypeConfiguration<Person>
    {

        public PersonMapping()
        {

            HasKey(p => p.PersonId);

            Property(p => p.PersonKey).IsRequired();
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.Email).IsRequired();
            Property(p => p.Name).IsRequired();
            Property(p => p.FacebookId).IsOptional();
            Property(p => p.TwitterId).IsOptional();
            Property(p => p.GenderEnum).IsRequired();
            Property(p => p.MobilePhone).IsOptional();
            Property(p => p.HomePhone).IsOptional();
            Property(p => p.WorkPhone).IsOptional();
            Property(p => p.BirthDate).IsRequired();
            Property(p => p.BalanceInCents).IsOptional();
            Property(p => p.LoanTypeEnum).IsOptional();
            Property(p => p.LoanInCents).IsOptional();
            Property(p => p.DueDate).IsOptional();
            Property(p => p.TaxPerDay).IsOptional();
            Property(p => p.Name).IsRequired();
            Property(p => p.IsEnabled).IsRequired();
            Property(p => p.Username).IsRequired();
            Property(p => p.Password).IsRequired();
            Property(p => p.BearerToken).IsOptional();

        }
    }
}
