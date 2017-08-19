using System.Data.Entity.ModelConfiguration;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Mappings
{

    class DocumentMapping : EntityTypeConfiguration<Document>
    {

        public DocumentMapping()
        {

            HasKey(p => p.DocumentId);

            Property(p => p.PersonId).IsRequired();
            Property(p => p.DocumentType).IsRequired();
            Property(p => p.DocumentNumber).IsRequired();

            HasRequired(p => p.Person).WithMany(p => p.Documents).HasForeignKey(p => p.PersonId);
        }
    }
}
