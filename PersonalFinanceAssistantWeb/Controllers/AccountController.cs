using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet("{accountId}")]
    [ProducesResponseType(200, Type = typeof(List<Transaction>))]
    [ProducesResponseType(404)]
    public IActionResult GetAllTransactions(int accountId)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Account>))]
    [ProducesResponseType(400)]
    public IActionResult GetAllAccounts()
    {
        throw new NotImplementedException();
    }


    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateAccount([FromBody] AccountDto accountDto)
    {
        throw new NotImplementedException();
    }

    [HttpPost("{accountId}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult CreateTransaction(int accountId,[FromBody] TransactionDto transactionDto)
    {
        throw new NotImplementedException();
    }

    [HttpPut("{accountId}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateAccountName(int accountId, [FromBody] AccountDto accountDto)
    {
        throw new NotImplementedException();
    }
}