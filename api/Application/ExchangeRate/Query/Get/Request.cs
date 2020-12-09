using System;
using MediatR;

namespace Application.ExchangeRate.Query.Get
{
    public class Request : IRequest<Response>
    {
        public DateTime Date { get; set; }
    }
}
