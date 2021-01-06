using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using CoreHtmlToImage;

namespace Api.Services
{
    public class ImageService : IImageService
    {
		private readonly IExchangeRateService _exchangeRateService;
		public ImageService(IExchangeRateService exchangeRateService)
		{
			_exchangeRateService = exchangeRateService;
		}
        public async Task<bool> CreateImage(ExchangeRateResponse exchangeRateResponse)
        {
            try
            {

				exchangeRateResponse.Date = DateTime.Now.Date.ToString(DateTime.Now.ToString("dd/MM/yyyy"));

                var converter = new HtmlConverter();
				string usd = $"{exchangeRateResponse.Rates.Usd:0.000}";
				string eur = $"{exchangeRateResponse.Rates.Eur:0.000}";
				string gbp = $"{exchangeRateResponse.Rates.Gbp:0.000}";

                var html = $@"<style>
										.demo {{
											width:1080px;
											height:1080px;
											border:1px none;
											padding:5px;
										}}
										.demo th {{
											border:1px none;
											padding:5px;
										}}
										.demo td {{
											border:1px none;
											padding:5px;
										}}
									</style>
									<table class=""demo"">
										<caption><br></caption>
										<tbody>
										<tr>
											<td>&nbsp;</td>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <strong style=""font-size: 70px;"">
														 	{exchangeRateResponse.Date}
														 </strong>
											</td>
										</tr>
										<tr>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">														
														<img src=""https://www.countryflags.com/wp-content/uploads/united-states-of-america-flag-png-large.png"" width=""150"" height=""80"">			 
														<strong style=""font-size: 70px;"">
														 	   Dolar
														 </strong>
											</td>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <strong style=""font-size: 70px;"">
														 	{usd} &#8378;
														 </strong>
											</td>
										</tr>
										<tr>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <img src=""https://www.countryflags.com/wp-content/uploads/europe-flag-jpg-xl.jpg"" width=""150"" height=""80"">	
														 <strong style=""font-size: 70px;"">
														 	   Euro
														 </strong>
											</td>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <strong style=""font-size: 70px;"">
														 	{eur} &#8378;
														 </strong>
											</td>
										</tr>
										<tr>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <img src=""https://www.countryflags.com/wp-content/uploads/united-kingdom-flag-png-large.png"" width=""150"" height=""80"">	
														 <strong style=""font-size: 70px;"">
														 	   Sterlin
														 </strong>
											</td>
											<td style=""padding-left: 25px;
                 										padding-bottom: 3px;
                 										font-family:verdana"">
														 <strong style=""font-size: 70px;"">
														 	{gbp} &#8378;
														 </strong>
											</td>
										</tr>
										<tbody>
									</table>";
                var bytes = converter.FromHtmlString(html, 1080);
                File.WriteAllBytes("image.jpg", bytes);


                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }

        }
    }


}