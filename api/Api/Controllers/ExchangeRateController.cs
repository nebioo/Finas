using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ExchangeRateController : ApiController
  {
    private readonly IMediator _mediator;
    private readonly ILogger<ExchangeRateController> _logger;

    public ExchangeRateController(
        IMediator mediator,
        ILogger<ExchangeRateController> logger
    )
    {
      _mediator = mediator;
      _logger = logger;
    }

    /// <summary>
    /// Doviz kurlarını çeker
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetExchangeRate")]
    public async Task<ActionResult> GetExchangeRate()
    {
      var response = await _mediator.Send(new Application.ExchangeRate.Query.GetExchangeRate.Request());
      if (response == null)
        throw new ArgumentNullException(nameof(response));

      return Ok(response);
    }
  }
}
