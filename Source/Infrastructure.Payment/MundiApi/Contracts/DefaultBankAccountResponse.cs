using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Payment.MundiApi.Contracts
{

    public class DefaultBankAccountResponse
    {
        public string id { get; set; }
        public string holder_name { get; set; }
        public string holder_type { get; set; }
        public string holder_document { get; set; }
        public string bank { get; set; }
        public string branch_number { get; set; }
        public string branch_check_digit { get; set; }
        public string account_number { get; set; }
        public string account_check_digit { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
