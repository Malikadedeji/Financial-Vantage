namespace FinancialVantage.Application
{
    public interface IAlphaVantageService
    {
        Task<string> GetStockDataAsync(string symbol);
    }
}
