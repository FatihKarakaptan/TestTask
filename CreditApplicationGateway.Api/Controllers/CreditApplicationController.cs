using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreditApplicationGateway.Api.Contracts.Request.CreditApplication;
using CreditApplicationGateway.Api.Contracts.Response.CreditApplication;
using CreditApplicationGateway.Business.Contracts.CreditApplication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditApplicationGateway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {
        private readonly ICreditApplicationService _creditApplicationService;

        public CreditApplicationController(ICreditApplicationService creditApplicationService)
        {
            _creditApplicationService = creditApplicationService;
        }


        [HttpPost]
        public async Task<CreditApplicationResponse> GetCreditApplicationResultAsync(CreditApplicationRequest request)
        {
            return await _creditApplicationService.GetCreditApplicationResult(request);
        }

    }
}
