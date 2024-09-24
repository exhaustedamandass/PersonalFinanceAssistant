using System.Reflection.Metadata;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface IReportService
{
    Task<Report> GetReportByUserAsync(string userId);

    Task<List<Report>> GetAllReportsByUserAsync(string userId);

    Task<Report> GetReportByIdAsync(string reportId);

    void UpdateReport(string reportId, Report newReport);

    void AddReport(Report newReport);

    void DeleteReport(string reportId);
}