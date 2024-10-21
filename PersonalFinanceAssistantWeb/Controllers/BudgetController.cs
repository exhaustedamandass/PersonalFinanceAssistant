using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BudgetController : Controller
{
    private IBudgetService _budgetService;

    public BudgetController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet ("{budgetId:guid}")]
    [ProducesResponseType(200, Type = typeof(Budget))]
    [ProducesResponseType(404)]
    public IActionResult GetBudget(Guid budgetId)
    {
        var budget = _budgetService.GetBudget(budgetId);

        if (budget == null)
        {
            return NotFound();
        }

        return Ok(budget);
    }

    //PUT /api/budget/{budgetId}/limit
    [HttpPut ("{budgetId:guid}/limit")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateLimit(Guid budgetId, [FromBody] BudgetDto budgetDto)
    {
        if (budgetDto.Limit <= 0)
        {
            return BadRequest("Invalid budget data.");
        }

        var result = _budgetService.UpdateLimit(budgetId, budgetDto);

        if (!result)
        {
            return BadRequest("Failed to update the limit.");
        }

        return Accepted();
    }

    //PUT /api/budget/{budgetId}/spent
    [HttpPut("{budgetId:guid}/spent")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateSpent(Guid budgetId, [FromBody] BudgetDto budgetDto)
    {
        if (budgetDto.Spent < 0)
        {
            return BadRequest("Invalid budget data.");
        }

        var result = _budgetService.UpdateSpent(budgetId, budgetDto);

        if (!result)
        {
            return BadRequest("Failed to update the spent amount.");
        }

        return Accepted();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateBudget([FromBody] BudgetDto budgetDto)
    {
        if (budgetDto.Limit <= 0 || budgetDto.PeriodStart >= budgetDto.PeriodEnd)
        {
            return BadRequest("Invalid budget data.");
        }

        // Pass the DTO to the service without handling domain logic here
        var result = _budgetService.CreateNewBudget(budgetDto);

        if (!result)
        {
            return BadRequest("Failed to create the budget.");
        }

        return StatusCode(201); // 201 Created
    }

    [HttpDelete ("{budgetId:guid}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteBudget(Guid budgetId)
    {
        var result = _budgetService.DeleteBudget(budgetId);

        if (!result)
        {
            return NotFound("Budget not found.");
        }

        return NoContent(); // 204 No Content
    }
}