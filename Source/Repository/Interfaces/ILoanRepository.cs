using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MundiPagg.Benfeitor.Repository.Entities;

namespace MundiPagg.Benfeitor.Repository.Interfaces
{
    public interface ILoanRepository
    {
        void CreateLoanHistory(LoanHistory loanHistory);
        LoanHistory GetLoanHistory(long loanHistoryId);
    }
}
