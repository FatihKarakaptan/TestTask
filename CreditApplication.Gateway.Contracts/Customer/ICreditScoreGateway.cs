using CreditApplication.Gateway.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplication.Gateway.Contracts.CreditScore
{
    public interface ICreditScoreGateway : IBaseGateway
    {
        Task<int> GetCreditScoreAsync(string IdentityNumber);
    }
}
