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
        var transactions = _accountService.GetAllTransactions(accountId);
        
        if (transactions == null || transactions.Count == 0)
        {
            return NotFound($"Account with ID {accountId} not found or has no transactions.");
        }

        return Ok(transactions);
    }

    //TODO : account for some error in db???
    
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Account>))]
    public IActionResult GetAllAccounts()
    {
        return Ok(_accountService.GetAllAccounts());
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)] 
    [ProducesResponseType(409)] 
    [ProducesResponseType(500)] 
    public IActionResult CreateAccount([FromBody] AccountDto accountDto)
    {
        // Check if the incoming data is valid
        if (accountDto == null || !ModelState.IsValid)
        {
            return BadRequest("Invalid account data.");  // 400 Bad Request
        }

        // Let the service handle account creation including mapping
        var accountCreated = _accountService.CreateNewAccount(accountDto);

        if (accountCreated)
        {
            // Return 201 Created with a location header
            return CreatedAtAction(nameof(CreateAccount), new { accountId = accountDto. }, accountDto);
        }
        else
        {
            // Handle conflict or internal server errors
            if (_accountService.IsDuplicateAccount(accountDto))
            {
                return Conflict("Account with the same name already exists.");  // 409 Conflict
            }

            return StatusCode(500, "An error occurred while creating the account.");  // 500 Internal Server Error
        }
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