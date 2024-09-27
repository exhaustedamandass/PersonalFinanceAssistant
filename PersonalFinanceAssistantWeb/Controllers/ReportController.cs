using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

public class ReportController : Controller
{
    private IReportService _reportService;

    [HttpGet("{userId}/{reportId}")]
    [ProducesResponseType(200, Type = typeof(Report))]
    [ProducesResponseType(404)]
    public IActionResult GetReportByUser(int userId, int reportId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{userId}")]
    [ActionName("GetHistory")]
    [ProducesResponseType(200, Type = typeof(List<Transaction>))]
    [ProducesResponseType(404)]
    public IActionResult GetReportsHistoryByUser(int userId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{userId}")]
    [ActionName("GenerateReport")]
    [ProducesResponseType(200, Type = typeof(Transaction))]
    [ProducesResponseType(404)]
    public IActionResult GenerateReport(int userId)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{userId}/{reportId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeleteReport(int userId, int reportId)
    {
        throw new NotImplementedException();
    }
}