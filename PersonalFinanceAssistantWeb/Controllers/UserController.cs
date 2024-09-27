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

    [HttpPut ("{userId}")]
    [ActionName("UpdateUsername")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateUserName(int userId, [FromBody] UserDto userDto)
    {
        throw new NotImplementedException();
    }

    [HttpPut ("{userId}")]
    [ActionName("UpdateEmail")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateEmail(int userId, [FromBody] UserDto userDto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{userId}/{accountId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteAccount(int userId, int accountId)
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{userId}/{budgetId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteBudget(int userId, int budgetId)
    {
        throw new NotImplementedException();
    }

    [HttpPost ("{userId}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult AddAccount(int userId, [FromBody] AccountDto accountDto)
    {
        throw new NotImplementedException();
    }

    [HttpPost ("{userID}")]
    public IActionResult AddBudget(int userID, [FromBody] BudgetDto budgetDto)
    {
        throw new NotImplementedException();
    }
    
}