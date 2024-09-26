using FinancialVantage.Application.Interfaces;
using FinancialVantage.Application.Services;
using FinancialVantage.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FinancialVantage.API.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class FinancialTransactionController : ControllerBase
    {
        private readonly IFinancialTransactionService _transactionService;
        private readonly ILogger<FinancialTransactionController> _logger;

        public FinancialTransactionController(FinancialTransactionService transactionService,
            ILogger<FinancialTransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _transactionService.GetTransactionByIdAsync(id);

            //if (transaction == null)
            //    return NotFound();

            if (transaction == null)
            {
                return NotFound(new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.NotFound,
                    Message = "No transactions found."
                });
            }

            return Ok(transaction);
        }

        [Produces("application/json")]
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTransactions(string userId, 
            [FromQuery] PaginationParameters paginationParams)
        {
            try
            {
                _logger.LogInformation("Fetching transactions for user {UserId}", userId);

                var transactions = await _transactionService.GetAllTransactionsForUserAsync(userId, paginationParams);

                if (transactions == null || !transactions.Any())
                {
                    _logger.LogWarning("No transaction found for the user {UserId}", userId);
                    //return NotFound("No transaction Found");
                    return NotFound(new ErrorDetails
                    {
                        StatusCode = (int)HttpStatusCode.NotFound,
                        Message = "No transactions found."
                    });
                }
                return Ok(transactions);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while fetching transaction for user {UserId}, userId");
                return StatusCode((int)HttpStatusCode.InternalServerError, new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "An unexpected error occured. Please try again later."
                });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(FinancialTransaction model)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(new ErrorDetails
                {
                    StatusCode = (int)HttpStatusCode.BadRequest,
                    Message = "Invalid request. Please check the input data."
                });

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
