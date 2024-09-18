using FinancialVantage.Application;
using Microsoft.AspNetCore.Mvc;

namespace FinancialVantage.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class StocksController : ControllerBase
    {
        private readonly IAlphaVantageService _alphaVantageService;

        public StocksController(IAlphaVantageService alphaVantageService)
        {
            _alphaVantageService = alphaVantageService;
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetStockData(string symbol)
        {
            var data = await _alphaVantageService.GetStockDataAsync(symbol);
            return Ok(data);
        }
    }
}
