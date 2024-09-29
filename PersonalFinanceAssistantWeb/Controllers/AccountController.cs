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

    [HttpGet("{accountId:guid}")]
    [ProducesResponseType(200, Type = typeof(List<Transaction>))]
    [ProducesResponseType(404)]
    public IActionResult GetAllTransactions(Guid accountId)
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
    
    //TODO : refactor this part
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)] 
    [ProducesResponseType(409)] 
    [ProducesResponseType(500)] 
    public IActionResult CreateAccount([FromBody] AccountDto accountDto)
    {
        // Check if the incoming data is valid
        if (!ModelState.IsValid)
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
            return _accountService.IsDuplicateAccount(accountDto)
                ? Conflict("Account with the same name already exists.")
                : // 409 Conflict
                StatusCode(500, "An error occurred while creating the account."); // 500 Internal Server Error
        }
    }

    [HttpPost("{accountId:guid}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult CreateTransaction(Guid accountId,[FromBody] TransactionDto transactionDto)
    {
        // Call the service to add the transaction
        try
        {
            _accountService.AddTransaction(accountId, transactionDto);
            return Accepted(); // 202 Accepted
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (Exception ex)
        {
            // Log the exception if necessary
            return StatusCode(500, "Internal server error"); // 500 Internal Server Error
        }
    }

    [HttpPut("{accountId:guid}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateAccountName(Guid accountId, [FromBody] AccountDto accountDto)
    {
        if (string.IsNullOrWhiteSpace(accountDto.Name))
        {
            return BadRequest("Account data is null or the name is empty.");
        }

        // Call the service to update the account name
        try
        {
            _accountService.UpdateAccountName(accountId, accountDto.Name);
            return Accepted(); // 202 Accepted
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message); // 404 Not Found
        }
        catch (Exception ex)
        {
            // Log the exception if necessary
            return StatusCode(500, "Internal server error"); // 500 Internal Server Error
        }
    }
}