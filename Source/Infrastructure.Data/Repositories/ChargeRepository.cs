using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories
{

    public class ChargeRepository : Repository<Charge>, IChargeRepository
    {

        public ChargeRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
