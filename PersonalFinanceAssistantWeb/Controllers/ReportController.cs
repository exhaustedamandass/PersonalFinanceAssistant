using Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using PersonalFinanceAssistant.Entities;
using PersonalFinanceAssistant.Services;

namespace PersonalFinanceAssistantWeb.Controllers;

public class ReportController : Controller
{
    private IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("{userId:guid}/{reportId:guid}")]
    [ProducesResponseType(200, Type = typeof(ReportDto))]
    [ProducesResponseType(404)]
    public IActionResult GetReportByUser(Guid userId, Guid reportId)
    {
        // Call the service to get the report by user and report ID
        var reportDto = _reportService.GetReportByUser(userId, reportId);

        if (reportDto == null)
        {
            return NotFound("Report not found.");
        }

        // Return the report with a 200 OK status
        return Ok(reportDto);
    }

    [HttpGet("{userId:guid}/history")]
    [ProducesResponseType(200, Type = typeof(List<ReportDto>))]
    [ProducesResponseType(404)]
    public IActionResult GetReportsHistoryByUser(Guid userId)
    {
        // Call the service to get all reports for the user
        var reports = _reportService.GetAllReportsByUser(userId);

        if (reports.Count == 0)
        {
            return NotFound("No reports found for this user.");
        }

        // Return the list of reports with a 200 OK status
        return Ok(reports);
    }

    [HttpGet("{userId:guid}/newReport")]
    [ProducesResponseType(200, Type = typeof(ReportDto))]
    [ProducesResponseType(404)]
    public IActionResult GenerateReport(Guid userId)
    {
        var newReport = _reportService.GenerateReport(userId);

        if (newReport == null)
        {
            return NotFound("User not found or unable to generate report.");
        }

        // Return the newly created report with a 200 OK status
        return Ok(newReport);
    }

    [HttpDelete("{userId:guid}/{reportId:guid}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult DeleteReport(Guid userId, Guid reportId)
    {
        // Call the service to delete the report
    var result = _reportService.DeleteReport(userId, reportId);

    if (!result)
    {
        return NotFound("Report not found or user unauthorized to delete the report.");
    }

    // Return 200 OK if deletion was successful
    return Ok("Report successfully deleted.");
    }
}