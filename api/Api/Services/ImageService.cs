using System.IO;
using Api.Interfaces;
using Api.Models;
using CoreHtmlToImage;

namespace Api.Services
{
    public class ImageService : IImageService
    {
        public bool CreateImage(ExchangeRateRequest request)
        {
            try
            {
                var converter = new HtmlConverter();

                var html = @"<style>
	.demo {
		width:1080px;
		height:1080px;
		border:1px none;
		padding:5px;
	}
	.demo th {
		border:1px none;
		padding:5px;
	}
	.demo td {
		border:1px none;
		padding:5px;
	}
</style>
<table class=""demo"">
	<caption><br></caption>
	<tbody>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
		<td>&nbsp;</td>
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