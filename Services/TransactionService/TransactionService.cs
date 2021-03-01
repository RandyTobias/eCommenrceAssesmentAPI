using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eCommerceAssessment.Models;
using eCommerceAssessment.Dtos.Transaction;
using eCommerceAssessment.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace eCommerceAssessment.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public TransactionService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<TransactionGetDto>>> AddTransaction(TransactionAddDto newTransaction)
        {
            ServiceResponse<List<TransactionGetDto>> serviceResponse = new ServiceResponse<List<TransactionGetDto>>(); 
            Transaction transaction = _mapper.Map<Transaction>(newTransaction);
            try
            {
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
                serviceResponse.Data = (_context.Transactions.Select(u => _mapper.Map<TransactionGetDto>(u))).ToList();
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TransactionGetDto>>> GetAllTransactions()
        {
            ServiceResponse<List<TransactionGetDto>> serviceResponse = new ServiceResponse<List<TransactionGetDto>>();
            try
            {
                if (_context.Transactions != null)
                {
                    List<Transaction> dbTransactions = await _context.Transactions.ToListAsync();
                    serviceResponse.Data = dbTransactions.Select(u => _mapper.Map<TransactionGetDto>(u)).ToList();
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TransactionGetDto>> GetTransactionById(int id)
        {
            ServiceResponse<TransactionGetDto> serviceResponse = new ServiceResponse<TransactionGetDto>();
            try
            {
                Transaction dbTransaction = await _context.Transactions.FirstOrDefaultAsync(u => u.id == id);
                serviceResponse.Data = _mapper.Map<TransactionGetDto>(dbTransaction); 
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<TransactionGetDto>> UpdateTransaction(TransactionUpdateDto updatedTransaction)
        {
            ServiceResponse<TransactionGetDto> serviceResponse = new ServiceResponse<TransactionGetDto>();
            try{
                Transaction transaction = await _context.Transactions.FirstOrDefaultAsync(u => u.id == updatedTransaction.id);

                transaction.id = updatedTransaction.id;
                transaction.userid = updatedTransaction.user;
                transaction.shippingProviderid = updatedTransaction.shippingProvider;
                transaction.shippingAddressid = updatedTransaction.shippingAddress;
                transaction.total = updatedTransaction.total;

                _context.Transactions.Update(transaction);
                await _context.SaveChangesAsync();
                serviceResponse.Data = _mapper.Map<TransactionGetDto>(transaction);
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TransactionGetDto>>> DeleteTransaction(int id)
        {
            ServiceResponse<List<TransactionGetDto>> serviceResponse = new ServiceResponse<List<TransactionGetDto>>();
            try{
                Transaction transaction = await _context.Transactions.FirstAsync(u => u.id == id);
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = (_context.Transactions.Select(u => _mapper.Map<TransactionGetDto>(u))).ToList();
            }
            catch (Exception ex) {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
            return serviceResponse;
        }
    }
}