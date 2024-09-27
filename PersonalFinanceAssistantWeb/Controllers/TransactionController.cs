using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

[Route("api/[controller]")]
public class TransactionController : Controller
{
    private ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpDelete("{transactionId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateTransaction([FromBody] TransactionDto transactionDto)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{transactionId}")]
    [ProducesResponseType(200, Type = typeof(Transaction))]
    [ProducesResponseType(404)]
    public IActionResult GetTransaction(int transactionId)
    {
        throw new NotImplementedException();
    }

    [HttpPut ("{transactionId}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateTransaction(int transactionId, [FromBody] TransactionDto transactionDto)
    {
        throw new NotImplementedException();
    }
}