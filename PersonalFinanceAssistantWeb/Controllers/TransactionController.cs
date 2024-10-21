using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : Controller
{
    private ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpDelete("{transactionId:guid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteTransaction(Guid transactionId)
    {
        var result = _transactionService.DeleteTransaction(transactionId);

        // If the transaction was not found, return 404
        if (!result)
        {
            return NotFound("Transaction not found.");
        }

        // If the transaction was successfully deleted, return 204 No Content
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateTransaction([FromBody] TransactionDto transactionDto)
    {
        if (transactionDto.Amount <= 0)
        {
            return BadRequest("Invalid transaction data.");
        }

        // Call the service to create the transaction
        var result = _transactionService.CreateTransaction(transactionDto);

        if (!result)
        {
            return BadRequest("Failed to create the transaction.");
        }

        return StatusCode(201); // 201 Created
    }

    [HttpGet("{transactionId:guid}")]
    [ProducesResponseType(200, Type = typeof(TransactionDto))]
    [ProducesResponseType(404)]
    public IActionResult GetTransaction(Guid transactionId)
    {
        // Call the service to retrieve the transaction
        var transaction = _transactionService.GetSingleTransaction(transactionId);

        // If the transaction is not found, return 404 Not Found
        if (transaction == null)
        {
            return NotFound("Transaction not found.");
        }

        // Return the transaction with a 200 OK status
        return Ok(transaction);
    }

    [HttpPut ("{transactionId:guid}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateTransaction(Guid transactionId, [FromBody] TransactionDto transactionDto)
    {
        if (transactionDto.Amount <= 0)
        {
            return BadRequest("Invalid transaction data.");
        }

        // Call the service to update the transaction
        var result = _transactionService.UpdateTransaction(transactionId, transactionDto);

        if (!result)
        {
            return BadRequest("Failed to update the transaction or transaction not found.");
        }

        return Accepted(); // 202 Accepted
    }
}