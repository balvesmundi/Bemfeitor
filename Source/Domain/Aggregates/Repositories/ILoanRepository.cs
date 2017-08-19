using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Seedwork;

namespace MundiPagg.Benfeitor.Domain.Aggregates.Repositories
{
    public interface ILoanRepository : IRepository<LoanHistory> { }
}
