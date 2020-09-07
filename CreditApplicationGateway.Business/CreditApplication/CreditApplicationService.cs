using CreditApplication.Gateway.Contracts.CreditScore;
using CreditApplicationGateway.Api.Contracts.Request.CreditApplication;
using CreditApplicationGateway.Api.Contracts.Response.CreditApplication;
using CreditApplicationGateway.Business.Base;
using CreditApplicationGateway.Business.Contracts.CreditApplication;
using CreditApplicationGateway.Data.Contracts.CreditApplication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationGateway.Business.CreditApplication
{
    public class CreditApplicationService : BaseService, ICreditApplicationService
    {
        private readonly ICreditScoreGateway _creditScoreGateway;
        private readonly ICreditApplicationRepository _creditApplicationRepository;
        private const int CreditLimitMultipilier = 4;

        public CreditApplicationService(ICreditScoreGateway creditScoreGateway, ICreditApplicationRepository creditApplicationRepository)
        {
            _creditScoreGateway = creditScoreGateway;
            _creditApplicationRepository = creditApplicationRepository;
        }
        public async Task<CreditApplicationResponse> GetCreditApplicationResult(CreditApplicationRequest request)
        {
            try
            {
                var creditScore = await _creditScoreGateway.GetCreditScoreAsync(request.IdentityNumber);

                if(creditScore < 1000 && request.Salary >= 5000)
                {
                    var result = _creditApplicationRepository.SaveTransactionAsync(request.IdentityNumber, 10000);
                    return new CreditApplicationResponse
                    {
                        IsSucceed = true,
                        CreditApplicationResult = true,
                        CreditLimit = 10000
                    };
                }
                else if(creditScore >= 1000)
                {
                    var result = _creditApplicationRepository.SaveTransactionAsync(request.IdentityNumber, request.Salary * CreditLimitMultipilier);
                    return new CreditApplicationResponse
                    {
                        IsSucceed = true,
                        CreditApplicationResult = true,
                        CreditLimit = request.Salary * CreditLimitMultipilier
                    };
                }
                else
                {
                    return new CreditApplicationResponse
                    {
                        IsSucceed = true,
                        CreditApplicationResult = false
                    };
                }

            }
            catch(Exception ex)
            {
                //Log Exception
                Console.WriteLine(ex.ToString());
                return new CreditApplicationResponse
                {
                    IsSucceed = false,
                    CreditApplicationResult = false
                };
            }
        }
    }
}
