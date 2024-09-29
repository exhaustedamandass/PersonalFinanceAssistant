using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

public class UserController : Controller
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut ("{userId:guid}/username")]
    [ActionName("UpdateUserName")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateUserName(Guid userId, [FromBody] UserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.UserName))
        {
            return BadRequest("Invalid user data.");
        }

        // Call the service to update the user's name
        var result = _userService.UpdateUserName(userId, userDto.UserName);

        if (!result)
        {
            return BadRequest("Failed to update the user or user not found.");
        }

        return Accepted(); // 202 Accepted
    }

    [HttpPut ("{userId:guid}/email")]
    [ActionName("UpdateEmail")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateEmail(Guid userId, [FromBody] UserDto userDto)
    {
        if (string.IsNullOrWhiteSpace(userDto.Email) || !IsValidEmail(userDto.Email))
        {
            return BadRequest("Invalid email address.");
        }

        // Call the service to update the user's email
        var result = _userService.UpdateEmail(userId, userDto.Email);

        if (!result)
        {
            return BadRequest("Failed to update the email or user not found.");
        }

        return Accepted(); // 202 Accepted
    }
    
    [HttpDelete("{userId:guid}/{accountId:guid}/account")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteAccount(Guid userId, Guid accountId)
    {
        var result = _userService.DeleteAccount(userId, accountId);

        if (!result)
        {
            return NotFound("Account not found or user is unauthorized.");
        }

        return NoContent(); // 204 No Content
    }
    
    [HttpDelete("{userId:guid}/{budgetId:guid}/budget")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteBudget(Guid userId, Guid budgetId)
    {
        var result = _userService.DeleteBudget(userId, budgetId);

        if (!result)
        {
            return NotFound("Budget not found or user is unauthorized.");
        }

        return NoContent(); // 204 No Content
    }

    [HttpPost("{userId:guid}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult AddAccount(Guid userId, [FromBody] AccountDto accountDto)
    {
        if (string.IsNullOrWhiteSpace(accountDto.AccountName))
        {
            return BadRequest("Invalid account data.");
        }

        // Call the service to add the account
        var result = _userService.AddAccount(userId, accountDto);

        if (!result)
        {
            return BadRequest("Failed to create the account.");
        }

        return StatusCode(201); // 201 Created
    }

    [HttpPost ("{userID:guid}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult AddBudget(Guid userId, [FromBody] BudgetDto budgetDto)
    {
        // Call the service to add the budget
        var result = _userService.AddBudget(userId, budgetDto);

        if (!result)
        {
            return BadRequest("Failed to create the budget.");
        }

        return StatusCode(201); // 201 Created
    }
    
    // Email validation helper function
    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}
