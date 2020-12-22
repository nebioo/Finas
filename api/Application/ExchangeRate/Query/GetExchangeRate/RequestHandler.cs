using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;

namespace Application.ExchangeRate.Query.GetExchangeRate
{
  public class RequestHandler : IRequestHandler<Request, Response>
  {
    public RequestHandler()
    {
    }


    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
      try
      {

        var today = DateTime.Now;

        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(GetUrl(today), cancellationToken);

        var stringResponse = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Response>(stringResponse);

        double one = 1.00;
        result.Base = "TRY";
        result.Rates.Usd = result.Rates.Try / result.Rates.Usd;
        result.Rates.Eur = result.Rates.Try;
        result.Rates.Gbp = result.Rates.Try / result.Rates.Gbp;
        result.Rates.Try = one;


        return result;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }

    }

    private static string GetUrl(DateTime? date = null)
    {

      const string baseUrl = "http://data.fixer.io/api/";
      const string baseUrlEnd = "?access_key=35245b7a848e449753f531a4560abae6&symbols=USD,GBP,TRY";
      StringBuilder sb = new StringBuilder();
      var dateString = date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "lastDate";
      sb.Append(baseUrl);
      sb.Append(dateString);
      sb.Append(baseUrlEnd);

      return sb.ToString();
    }


  }
}
