using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data.Seedwork;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Repositories
{

    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {

        public DocumentRepository(UnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
