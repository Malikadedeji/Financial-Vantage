using FinancialVantage.Domain;

namespace FinancialVantage.Application.Interfaces
{
    public interface IFinancialTransactionService
    {
        Task<FinancialTransaction> CreateTransactionAsync(FinancialTransaction transaction);
        Task<FinancialTransaction> UpdateTransactionAsync(FinancialTransaction transaction);
        Task<bool> DeleteTransactionAsync(int transactionId);
        Task<FinancialTransaction> GetTransactionByIdAsync(int transactionId);
        Task<IEnumerable<FinancialTransaction>> GetAllTransactionsForUserAsync(string userId);
    }
}
