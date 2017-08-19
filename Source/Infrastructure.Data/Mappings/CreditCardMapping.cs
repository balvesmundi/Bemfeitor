using MundiPagg.Subscriber.Domain.Aggregates.CustomerAgg.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Subscriber.Infrastructure.Data.Mappings {

    class CreditCardMapping : EntityTypeConfiguration<CreditCard> {

        public CreditCardMapping() {

            HasKey(p => p.Id);

            Property(p => p.ExternalId).IsRequired().HasMaxLength(36);
            Property(p => p.Fingerprint).IsRequired().HasMaxLength(128);
            Property(p => p.PGID).IsOptional().HasMaxLength(36);
            Property(p => p.LastFourDigits).IsRequired().HasMaxLength(4);
            Property(p => p.FirstSixDigits).IsRequired().HasMaxLength(6);
            Property(p => p.Number).IsOptional().HasMaxLength(512);
            Property(p => p.Brand).IsRequired().HasMaxLength(32);
            Property(p => p.CardType).IsOptional().HasMaxLength(64);
            Property(p => p.Bank).IsOptional().HasMaxLength(64);
            Property(p => p.Country).IsOptional().HasMaxLength(32);
            Property(p => p.HolderName).IsRequired().HasMaxLength(64);
            Property(p => p.ExpDate).IsRequired();
            Property(p => p.CreatedAt).IsRequired();
            Property(p => p.UpdatedAt).IsRequired();
            Property(p => p.DeletedAt).IsOptional();
            Property(p => p.Status).IsRequired().HasMaxLength(16);

            HasRequired(p => p.Customer).WithMany().HasForeignKey(p => p.CustomerId);

            Ignore(p => p.ExpMonth);
            Ignore(p => p.ExpYear);
            Ignore(p => p.IsExpired);
        }
    }
}
