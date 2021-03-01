using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Transaction;

namespace eCommerceAssessment.Services.TransactionService
{
    public interface ITransactionService
    {
        Task<ServiceResponse<List<TransactionGetDto>>> GetAllTransactions();
        Task<ServiceResponse<TransactionGetDto>> GetTransactionById(int id);
        Task<ServiceResponse<List<TransactionGetDto>>> AddTransaction(TransactionAddDto newTransaction);
        Task<ServiceResponse<TransactionGetDto>> UpdateTransaction(TransactionUpdateDto updatedTransaction);
        Task<ServiceResponse<List<TransactionGetDto>>> DeleteTransaction(int id);
    }
}