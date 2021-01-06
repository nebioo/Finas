using System;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ImageController : ApiController
  {
    private readonly IImageService _imageService;
    private readonly IExchangeRateService _exchangeRateService;
    private readonly ILogger<ImageController> _logger;

    public ImageController(
        IImageService imageService,
        IExchangeRateService exchangeRateService,
        ILogger<ImageController> logger
    )
    {
      _imageService = imageService;
      _exchangeRateService = exchangeRateService;
      _logger = logger;
    }

        /// <summary>
        /// Image Dosyasını oluşturur
        /// </summary>
        /// <returns></returns>
        [HttpGet("CreateImage")]
        public async Task CreateImage()
        {
            var exchangeRateData =await _exchangeRateService.GetExchangeRates();
            var response = await _imageService.CreateImage(exchangeRateData);
            if (response == false)
                throw new ArgumentNullException(nameof(response));
            
        }
    }
}