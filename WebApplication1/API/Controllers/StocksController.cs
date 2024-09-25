using FinancialVantage.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FinancialVantage.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
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
            try
            {
                var data = await _alphaVantageService.GetStockDataAsync(symbol);
                return Ok(data);
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Error fetching stock data: {ex.Message}");
            }
        }
    }
}
