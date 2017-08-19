using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories
{

    public class LoanRepository : Repository<LoanHistory>, ILoanRepository
    {

        public LoanRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
