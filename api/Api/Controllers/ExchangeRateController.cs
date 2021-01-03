using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Api.Interfaces;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExchangeRateController : ApiController
  {
    private readonly IExchangeRateService _exchangeRateService;
    private readonly ILogger<ExchangeRateController> _logger;

    public ExchangeRateController(
        IExchangeRateService exchangeRateService,
        ILogger<ExchangeRateController> logger
    )
    {
      _exchangeRateService = exchangeRateService;
      _logger = logger;
    }

    /// <summary>
    /// Doviz kurlarını çeker
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetExchangeRate")]
    public async Task<ActionResult> GetExchangeRate()
    {
      var response = await _exchangeRateService.GetExchangeRates();
      if (response == null)
        throw new ArgumentNullException(nameof(response));

      return Ok(response);
    }
  }
}
