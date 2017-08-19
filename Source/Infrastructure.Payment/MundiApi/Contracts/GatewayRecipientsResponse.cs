using System;

namespace Infrastructure.Payment.MundiApi.Contracts
{

    public class GatewayRecipientsResponse
    {
        public string gateway { get; set; }
        public string status { get; set; }
        public string pgid { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
