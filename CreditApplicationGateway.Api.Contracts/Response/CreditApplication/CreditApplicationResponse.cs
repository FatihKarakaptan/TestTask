using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApplicationGateway.Api.Contracts.Response.CreditApplication
{
    public class CreditApplicationResponse : BaseResponse
    {
        public bool CreditApplicationResult { get; set; }

        public int? CreditLimit { get; set; }
    }
}
