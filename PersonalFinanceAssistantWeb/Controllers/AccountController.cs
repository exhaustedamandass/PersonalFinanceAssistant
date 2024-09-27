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
    
    
    // Get: /transactions
    [HttpGet]
    public async Task<IActionResult> GetTransactionsAsync(string accountId)
    {
        var transactions = await _accountService.GetAllTransactionsAsync(accountId);
        return Ok(transactions);
    }
    
    
    
    
    
    
}