using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

public class UserController
{
    private IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPut ("{userId}")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateUserName(int userId, [FromBody] UserDto userDto)
    {
        throw new NotImplementedException();
    }
    
    
}