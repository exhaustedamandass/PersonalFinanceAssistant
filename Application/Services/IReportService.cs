using System.Reflection.Metadata;
using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IReportService
{
    ReportDto? GetReportByUser(Guid userId, Guid reportId);

    List<ReportDto> GetAllReportsByUser(Guid userId);

    Report GetReportById(Guid reportId);

    void UpdateReport(Guid reportId, Report newReport);

    ReportDto? GenerateReport(Guid userId);

    void AddReport(Guid userId, ReportDto newReport);

    bool DeleteReport(Guid userId, Guid reportId);
}