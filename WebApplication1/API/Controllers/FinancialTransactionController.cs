using FinancialVantage.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinancialVantage.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly FinancialTransactionService _transactionService
            ;

        public FinancialTransactionController(FinancialTransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);
            if (transaction == null) 
                return NotFound();

            return Ok(transaction);

        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTransactions(string userId)
        {
            var transactions = await _transactionService.GetAllTransactionsForUserAsync(userId);
            return Ok(transactions);
        }
    }
}
