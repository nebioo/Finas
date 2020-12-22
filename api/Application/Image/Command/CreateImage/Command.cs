using Domain.Entities;
using MediatR;

namespace Application.Image.Command.CreateImage
{
    public class Command : IRequest<Response>
    {
        public ExchangeRates ExchangeRate { get; set; }
    }
}