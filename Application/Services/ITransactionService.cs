using Application.Dtos;
using PersonalFinanceAssistant.Entities;

namespace PersonalFinanceAssistant.Services;

public interface ITransactionService
{
    List<Transaction> GetTransactions();

    Transaction? GetSingleTransaction(Guid transactionId);

    bool DeleteTransaction(Guid transactionId);

    bool UpdateTransaction(Guid transactionId, TransactionDto transactionDto);

    bool CreateTransaction(TransactionDto transactionDto);
}