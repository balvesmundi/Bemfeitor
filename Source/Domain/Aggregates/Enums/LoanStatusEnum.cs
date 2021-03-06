﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Aggregates.Enums
{
    public enum LoanStatusEnum
    {
        Undefined,
        PendingLenderMoney,
        PendingPaymentToBorrower,
        Borrowed,
        PendingBorrowerMoney,
        PendingPaymentToLender,
        Finished
    }
}
