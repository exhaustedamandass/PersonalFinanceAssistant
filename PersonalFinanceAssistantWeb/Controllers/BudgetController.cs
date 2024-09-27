using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

[Route("api/[controller]")]
public class BudgetController : Controller
{
    private IBudgetService _budgetService;

    public BudgetController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet ("{budgetId}")]
    [ProducesResponseType(200, Type = typeof(Budget))]
    [ProducesResponseType(404)]
    public IActionResult GetBudget(int budgetId)
    {
        throw new NotImplementedException();
    }

    //PUT /api/budget/{budgetId}/UpdateLimit
    [HttpPut ("{budgetId}")]
    [ActionName("UpdateLimit")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateLimit(int budgetId, [FromBody] BudgetDto budgetDto)
    {
        throw new NotImplementedException();
    }

    //PUT /api/budget/{budgetId}/UpdateSpent
    [HttpPut("{budgetId}")]
    [ActionName("UpdateSpent")]
    [ProducesResponseType(202)]
    [ProducesResponseType(400)]
    public IActionResult UpdateSpent(int budgetId, [FromBody] BudgetDto budgetDto)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public IActionResult CreateBudget([FromBody] BudgetDto budgetDto)
    {
        throw new NotImplementedException();
    }

    [HttpDelete ("{budgetId}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public IActionResult DeleteBudget(int budgetId)
    {
        throw new NotImplementedException();
    }
}