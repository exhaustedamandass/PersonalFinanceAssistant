using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistant.Controllers;

public class AccountController : ControllerBase
{
    private IAccountService _accountService;
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var accounts = await _accountService.GetAllAccountsAsync();
        return Ok(accounts);  // Or use a view if it's an MVC action
    }
    
    // Get: /transactions
    [HttpGet]
    public async Task<IActionResult> GetTransactionsAsync(string accountId)
    {
        var transactions = await _accountService.GetAllTransactionsAsync(accountId);
        return Ok(transactions);
    }
    
    
    
    
    
    
}