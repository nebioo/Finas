using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Interfaces
{
    public interface IImageService
    {
        public bool CreateImage(ExchangeRateRequest request);
    }
}