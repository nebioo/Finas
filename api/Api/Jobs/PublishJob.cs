using System;
using System.Threading.Tasks;
using Api.Interfaces;
using Quartz;

namespace Api.Jobs
{
    public class PublishJob : IJob
    {
        private readonly IExchangeRateService _exchangeRateService;
        private readonly IImageService _imageService;
        public PublishJob(IImageService imageService, IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
            _imageService = imageService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var exchangeRateData = await _exchangeRateService.GetExchangeRates();
                var image =  _imageService.CreateImage(exchangeRateData);
    
            }
            catch (Exception e)
            {                
                throw;
            }
            
        }
    }
}