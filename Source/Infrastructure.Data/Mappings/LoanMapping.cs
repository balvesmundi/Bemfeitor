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
            Property(p => p.LoanReason).IsOptional();
            Property(p => p.CreateDate).IsRequired();

            HasRequired(p => p.Borrower).WithMany(p => p.BorrowedLoans).HasForeignKey(p => p.PersonBorrowerId);
            HasRequired(p => p.Lender).WithMany(p => p.LendedLoans).HasForeignKey(p => p.PersonLenderId);

            HasRequired(p => p.Charge).WithMany(p => p.Loans).HasForeignKey(p => p.ChargeId);
            //HasRequired(p => p.Charge).WithOptional(p => p.LoanHistory);
        }
    }
}
