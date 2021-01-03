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
    private readonly ILogger<ImageController> _logger;

    public ImageController(
        IImageService imageService,
        ILogger<ImageController> logger
    )
    {
      _imageService = imageService;
      _logger = logger;
    }

        /// <summary>
        /// Image Dosyasını oluşturur
        /// </summary>
        /// <returns></returns>
        [HttpGet("CreateImage")]
        public ActionResult CreateImage([FromQuery] ExchangeRateRequest request)
        {
            var response = _imageService.CreateImage(request);
            if (response == false)
                throw new ArgumentNullException(nameof(response));

            return Ok(response);
        }
    }
}