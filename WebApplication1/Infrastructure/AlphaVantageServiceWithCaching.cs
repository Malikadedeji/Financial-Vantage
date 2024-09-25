using FinancialVantage.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FinancialVantage.Infrastructure
{
    public class AlphaVantageServiceWithCaching : IAlphaVantageService
    {
        private readonly IAlphaVantageService _innerService;
        private readonly IMemoryCache _cache;

        public AlphaVantageServiceWithCaching(IAlphaVantageService innerService, IMemoryCache cache)
        {
            _innerService = innerService;
            _cache = cache;
        }

        public async Task<string> GetStockDataAsync(string symbol)
        {
            if(_cache.TryGetValue(symbol, out string cachedData))
            {
                return cachedData;
            }

            var data = await _innerService.GetStockDataAsync(symbol);

            //Cache the data for 30 minutes.
            _cache.Set(symbol, data, TimeSpan.FromMinutes(30));

            return data;
        }
    }
}
