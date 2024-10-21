using Application.Dtos;
using AutoMapper;
using PersonalFinanceAssistant.Entities;

namespace Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AccountDto, Account>();
        CreateMap<TransactionDto, Transaction>();
        CreateMap<Transaction, TransactionDto>();
        CreateMap<BudgetDto, Budget>();
        CreateMap<ReportDto, Report>();
    }
}