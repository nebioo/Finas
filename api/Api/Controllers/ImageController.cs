using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class ImageController : ApiController
  {
    private readonly IMediator _mediator;
    private readonly ILogger<ImageController> _logger;

    public ImageController(
        IMediator mediator,
        ILogger<ImageController> logger
    )
    {
      _mediator = mediator;
      _logger = logger;
    }

    /// <summary>
    /// Image Dosyasını oluşturur
    /// </summary>
    /// <returns></returns>
    [HttpGet("CreateImage")]
    public async Task<ActionResult> CreateImage()
    {
        var response = await _mediator.Send(new Application.Image.Command.CreateImage.Command());
        if (response == null)
            throw new ArgumentNullException(nameof(response));
        
        return Ok(response);
    }
  }
}