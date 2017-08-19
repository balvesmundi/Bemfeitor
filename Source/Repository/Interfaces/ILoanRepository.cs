using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.Benfeitor.Repository.Interfaces
{
    public interface ILoanRepository
    {
        void CreateLoanHistory(LoanHistory loanHistory);
        LoanHistory GetLoanHistory(long loanHistoryId);
    }
}
