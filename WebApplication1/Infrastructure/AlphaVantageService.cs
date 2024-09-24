using FinancialVantage.Application.Interfaces;
using Microsoft.Extensions.Options;

namespace FinancialVantage.Infrastructure
{
    public class AlphaVantageService : IAlphaVantageService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AlphaVantageService(HttpClient httpClient, IOptions<AlphaVantageSettings> settings)
        {
            _httpClient = httpClient;
            _apiKey = settings.Value.ApiKey;
        }

        public async Task<string> GetStockDataAsync(string symbol)
        {
            string requestUrl = $"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey={_apiKey}";
            string response = await _httpClient.GetStringAsync(requestUrl);
            return response;
        }
    }
}
