using Application.Dtos;
using AutoMapper;
using Infrastructure.Data;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public class TransactionService : ITransactionService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public TransactionService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<Transaction> GetTransactions()
    {
        throw new NotImplementedException();
    }

    public Transaction? GetSingleTransaction(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public bool DeleteTransaction(Guid transactionId)
    {
        // Find the transaction by its ID
        var transactionEntity = _context.Transactions.FirstOrDefault(t => t.Id == transactionId);

        // If no transaction is found, return false
        if (transactionEntity == null)
        {
            return false;
        }

        // Remove the transaction from the database
        _context.Transactions.Remove(transactionEntity);

        // Save the changes
        _context.SaveChanges();

        return true;
    }

    public bool UpdateTransaction(Guid transactionId, TransactionDto transactionDto)
    {
        // Find the transaction in the database using the provided transactionId
        var existingTransaction = _context.Transactions.FirstOrDefault(t => t.Id == transactionId);

        if (existingTransaction == null)
        {
            return false; // Transaction not found
        }

        // Map the DTO to the existing entity
        _mapper.Map(transactionDto, existingTransaction);
        
        // Save changes to the database
        _context.SaveChanges();

        return true;
    }

    public bool CreateTransaction(TransactionDto transactionDto)
    {
        // Map the DTO to the entity using AutoMapper
        var transactionEntity = _mapper.Map<Transaction>(transactionDto);

        // Set additional properties, if necessary (e.g., a new GUID)
        transactionEntity.Id = Guid.NewGuid();

        // Add the transaction to the database
        _context.Transactions.Add(transactionEntity);

        // Save changes to the database
        _context.SaveChanges();

        return true;
    }
}