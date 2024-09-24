namespace FinancialVantage.Application.Interfaces
{
    public interface IAlphaVantageService
    {
        Task<string> GetStockDataAsync(string symbol);
    }
}
