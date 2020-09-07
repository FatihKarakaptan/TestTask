using CreditApplicationGateway.Data.Base;
using CreditApplicationGateway.Data.Contracts.CreditApplication;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplicationGateway.Data.CreditApplication
{
    public class CreditApplicationRepository : BaseRepository, ICreditApplicationRepository
    {
        private readonly string connectionString;
        public CreditApplicationRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public async Task<bool> SaveTransactionAsync(string IdentityNumber, int CreditLimit)
        {
            try 
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                String query = "INSERT INTO dbo.CreditInfo (IdentityNumber, ApplicationDate, CreditLimit) VALUES (@IdentityNumber, @ApplicationDate, @CreditLimit)";

                SqlCommand command = new SqlCommand(query, sqlConnection);
                command.Parameters.Add("@IdentityNumber", SqlDbType.NChar).Value = IdentityNumber;
                command.Parameters.Add("@ApplicationDate", SqlDbType.Date).Value = DateTime.Now;
                command.Parameters.Add("@CreditLimit", SqlDbType.Int).Value = CreditLimit;
                sqlConnection.Open();
                await command.ExecuteNonQueryAsync().ConfigureAwait(false);
                sqlConnection.Close();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //log exception
                return false;
            }
        }
    }
}
