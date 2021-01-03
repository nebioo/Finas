using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using Newtonsoft.Json;

namespace Api.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        #region  Get Exchange Rates Async
        public async Task<ExchangeRateResponse>  GetExchangeRates()
        {
            try
            {

                var today = DateTime.Now;

                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(GetUrl(today));

                response.EnsureSuccessStatusCode();
                var stringResponse = await response.Content.ReadAsStringAsync();


                var result = JsonConvert.DeserializeObject<ExchangeRateResponse>(stringResponse);

                double one = 1.00;
                result.Base = "TRY";
                result.Rates.Usd = result.Rates.Try / result.Rates.Usd;
                result.Rates.Eur = result.Rates.Try;
                result.Rates.Gbp = result.Rates.Try / result.Rates.Gbp;
                result.Rates.Try = one;


                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        #endregion

        #region  Get Url
        public string GetUrl(DateTime? date = null)
        {

            const string baseUrl = "http://data.fixer.io/api/";
            const string baseUrlEnd = "?access_key=35245b7a848e449753f531a4560abae6&symbols=USD,GBP,TRY";
            StringBuilder sb = new StringBuilder();
            var dateString = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "lastDate";
            sb.Append(baseUrl);
            sb.Append(dateString);
            sb.Append(baseUrlEnd);

            return sb.ToString();
        }
        #endregion
    }
}