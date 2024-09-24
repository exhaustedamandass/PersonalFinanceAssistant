using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class ReportService : IReportService
{
    public Task<Report> GetReportByUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Report>> GetAllReportsByUserAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<Report> GetReportByIdAsync(string reportId)
    {
        throw new NotImplementedException();
    }

    public void UpdateReport(string reportId, Report newReport)
    {
        throw new NotImplementedException();
    }

    public void AddReport(Report newReport)
    {
        throw new NotImplementedException();
    }

    public void DeleteReport(string reportId)
    {
        throw new NotImplementedException();
    }
}