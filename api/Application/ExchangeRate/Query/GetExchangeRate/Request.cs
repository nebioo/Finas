using System;
using MediatR;

namespace Application.ExchangeRate.Query.GetExchangeRate
{
  public class Request : IRequest<Response>
  {
    public DateTime Date { get; set; }
  }
}
