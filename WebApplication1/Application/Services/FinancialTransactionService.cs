using FinancialVantage.Application.Interfaces;
using FinancialVantage.Domain;
using FinancialVantage.Infrastructure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace FinancialVantage.Application.Services
{
    public class FinancialTransactionService : IFinancialTransactionService
    {
        private readonly AppDbContext _appDbContext;

        public FinancialTransactionService (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<FinancialTransaction> CreateTransactionAsync(FinancialTransaction transaction)
        {
            _appDbContext.FinancialTransactions.Add(transaction);
            await _appDbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<FinancialTransaction> UpdateTransactionAsync(FinancialTransaction transaction)
        {
            _appDbContext.FinancialTransactions.Update(transaction);
            await _appDbContext.SaveChangesAsync();
            return transaction;
        }

        public async Task<bool> DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _appDbContext.FinancialTransactions.FindAsync(transactionId);
            if (transaction == null) return false;

            _appDbContext.FinancialTransactions.Remove(transaction);
            _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<FinancialTransaction> GetTransactionByIdAsync(int transactionId)
        {
            return await _appDbContext.FinancialTransactions.FindAsync(transactionId);
        }

        public async Task<IEnumerable<FinancialTransaction>> GetAllTransactionsForUserAsync(string userId)
        {
            return await _appDbContext.FinancialTransactions
                .Where(t => t.UserId == userId)
                .ToListAsync();
        }
    }
}
