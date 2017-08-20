using System.Data.Entity.ModelConfiguration;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Mappings
{

    class ChargeMapping : EntityTypeConfiguration<Charge>
    {

        public ChargeMapping()
        {

            HasKey(p => p.ChargeId);

            Property(p => p.AmountInCents).IsRequired();
            Property(p => p.Code).IsRequired();
            Property(p => p.GatewayId).IsOptional();
            Property(p => p.Status).IsRequired();
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.PayerPersonId).IsRequired();

            HasRequired(p => p.Payer).WithMany(p => p.Charges).HasForeignKey(p => p.PayerPersonId);
        }
    }
}
