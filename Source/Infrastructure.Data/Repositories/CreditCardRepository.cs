using MundiPagg.Subscriber.Domain.Aggregates.CustomerAgg.Entities;
using MundiPagg.Subscriber.Domain.Aggregates.CustomerAgg.Repositories;
using MundiPagg.Subscriber.Infrastructure.Data.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Subscriber.Infrastructure.Data.Repositories {

    public class CreditCardRepository : Repository<CreditCard>, ICreditCardRepository {

        public CreditCardRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
