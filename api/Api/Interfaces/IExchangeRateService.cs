using System;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Interfaces
{
    public interface IExchangeRateService
    {
        public Task<ExchangeRateResponse> GetExchangeRates();
        public string GetUrl(DateTime? date = null);
    }
}