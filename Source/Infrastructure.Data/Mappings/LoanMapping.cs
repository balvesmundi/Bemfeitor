using System.Data.Entity.ModelConfiguration;
using Domain.Aggregates.Entities;

namespace MundiPagg.Benfeitor.Infrastructure.Data.Mappings {

    class LoanMapping : EntityTypeConfiguration<LoanHistory> {

        public LoanMapping() {

            HasKey(p => p.LoanHistoryId);

            Property(p => p.PersonLenderId).IsRequired();
            Property(p => p.CreateDate).IsRequired();
            Property(p => p.PersonBorrowerId).IsRequired();
            Property(p => p.LoanStatusEnum).IsRequired();
            Property(p => p.AmountInCents).IsRequired();
            Property(p => p.DueDate).IsOptional();
            Property(p => p.TaxPerDay).IsOptional();
            Property(p => p.LenderGrade).IsOptional();
            Property(p => p.BorrowerGrade).IsOptional();
            Property(p => p.CommentToLender).IsOptional();
            Property(p => p.CommentToBorrower).IsOptional();
            Property(p => p.CreateDate).IsRequired();

        }
    }
}
