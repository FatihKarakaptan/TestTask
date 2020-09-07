using CreditApplicationGateway.Api.Contracts.Request.CreditApplication;
using CreditApplicationGateway.Api.Contracts.Response.CreditApplication;
using CreditApplicationGateway.Business.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationGateway.Business.Contracts.CreditApplication
{
    public interface ICreditApplicationService : IBaseService
    {
        Task<CreditApplicationResponse> GetCreditApplicationResult(CreditApplicationRequest request);
    }
}
