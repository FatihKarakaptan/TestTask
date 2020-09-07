using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApplicationGateway.Api.Contracts.Request.CreditApplication
{
    public class CreditApplicationRequest : BaseRequest
    {
        public string IdentityNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public int Salary { get; set; }
    }
}
