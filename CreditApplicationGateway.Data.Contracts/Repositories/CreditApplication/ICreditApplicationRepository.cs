using CreditApplicationGateway.Data.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationGateway.Data.Contracts.CreditApplication
{
    public interface ICreditApplicationRepository : IBaseRepository
    {
        Task<bool> SaveTransactionAsync(string IdentityNumber, int CreditLimit);
    }
}
