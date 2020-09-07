using CreditApplication.Gateway.Base;
using CreditApplication.Gateway.Contracts.CreditScore;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CreditApplication.Gateway.Customer
{
    public class CreditScoreGateway : BaseGateway, ICreditScoreGateway
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly Random rand;//for mocking credit score result

        public CreditScoreGateway(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            rand = new Random();
        }
        public async Task<int> GetCreditScoreAsync(string IdentityNumber)
        {
            var client = _clientFactory.CreateClient();

            var request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:8080/api/GetCreditScore?id=" + IdentityNumber);

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    //request will fail so generate random int between 0-1500
                }
            }
            catch (Exception ex) 
            {
                //log Error
                Console.WriteLine(ex.ToString());
            }
            return rand.Next(0, 1501);
        }

    }
}
