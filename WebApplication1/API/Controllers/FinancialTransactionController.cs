using FinancialVantage.Application.Services;
using FinancialVantage.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FinancialVantage.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly FinancialTransactionService _transactionService;

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

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(FinancialTransaction model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newTransaction = await _transactionService.CreateTransactionAsync(model);
            return Ok(newTransaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, FinancialTransaction model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            model.Id = id;
            var updatedTransaction = _transactionService.UpdateTransactionAsync(model);
            return Ok(updatedTransaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var result = await _transactionService.DeleteTransactionAsync(id);
            if (!result)
                return NotFound();

            return Ok();
        }

    }
}
