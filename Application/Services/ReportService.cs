using Application.Dtos;
using AutoMapper;
using Infrastructure.Data;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class ReportService : IReportService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ReportService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReportDto? GetReportByUser(Guid userId, Guid reportId)
    {
        // Find the report by reportId and ensure it belongs to the given userId
        var reportEntity = _context.Reports.FirstOrDefault(r => r.Id == reportId && r.UserId == userId);

        if (reportEntity == null)
        {
            return null; // Report not found or does not belong to the user
        }

        // Map the ReportEntity to ReportDto
        var reportDto = _mapper.Map<ReportDto>(reportEntity);

        return reportDto;
    }

    public List<ReportDto> GetAllReportsByUser(Guid userId)
    {
        // Query the database for all reports belonging to the given userId
        var reportEntities = _context.Reports.Where(r => r.UserId == userId).ToList();

        if (reportEntities.Count == 0)
        {
            return []; // Return an empty list if no reports are found
        }

        // Map the list of ReportEntity to a list of ReportDto
        var reportDtos = _mapper.Map<List<ReportDto>>(reportEntities);

        return reportDtos;    
    }

    public Report GetReportById(Guid reportId)
    {
        throw new NotImplementedException();
    }

    public void UpdateReport(Guid reportId, Report newReport)
    {
        throw new NotImplementedException();
    }

    public ReportDto? GenerateReport(Guid userId)
    {
        // Fetch user by userId to check if the user exists
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return null; // User not found
        }

        //TODO : implement here
        
        // Create a new report (dummy data for this example)
        var reportEntity = new Report
        {
            Id = Guid.NewGuid(),
            UserId = user.Id,
            EndDate = DateTime.UtcNow
        };

        // Add the new report to the database
        _context.Reports.Add(reportEntity);
        _context.SaveChanges();

        // Map the entity to the DTO using AutoMapper
        var newReportDto = _mapper.Map<ReportDto>(reportEntity);

        return newReportDto;
    }

    public void AddReport(Guid userId, ReportDto newReport)
    {
        throw new NotImplementedException();
    }

    public bool DeleteReport(Guid userId, Guid reportId)
    {
        // Find the report by reportId and ensure it belongs to the given userId
        var reportEntity = _context.Reports.FirstOrDefault(r => r.Id == reportId && r.UserId == userId);

        if (reportEntity == null)
        {
            return false; // Report not found or does not belong to the user
        }

        // Remove the report from the database
        _context.Reports.Remove(reportEntity);

        // Save changes to the database
        _context.SaveChanges();

        return true;
    }
}