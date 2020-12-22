using System;

namespace Application.ExchangeRate.Query.GetExchangeRate
{
  [Serializable]
  public class Response
  {
    public bool Success { get; set; }
    public int Timestamp { get; set; }
    public bool Historical { get; set; }
    public string Base { get; set; }
    public string Date { get; set; }
    public Rates Rates { get; set; }
  }

  public class Rates
  {
    public double Usd { get; set; }
    public double Gbp { get; set; }
    public double Try { get; set; }
    public double Eur { get; set; }
  }

}
