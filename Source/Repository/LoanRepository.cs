using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class LoanRepository : ILoanRepository
    {
        public void CreateLoanHistory(LoanHistory loanHistory)
        {
            throw new NotImplementedException();
        }

        public LoanHistory GetLoanHistory(long loanHistoryId)
        {
            throw new NotImplementedException();
        }
    }
}
