using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories
{

    public class AddressRepository : Repository<Address>, IAddressRepository
    {

        public AddressRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
