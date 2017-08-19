using MundiPagg.Subscriber.Domain.Aggregates.ChargeAgg.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Subscriber.Infrastructure.Data.Mappings {
    public class CheckoutCardPaymentSettingsMapping : EntityTypeConfiguration<CheckoutCardPaymentSettings> {

        public CheckoutCardPaymentSettingsMapping() {
            HasKey(p => p.Id);

            Property(p => p.StatementDescriptor).IsOptional().HasMaxLength(22);

        }

    }
}
