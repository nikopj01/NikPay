using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using Payment.API.Controllers;
using Payment.API.Data.Interface;
using Payment.API.Entities;
using Payment.API.Repositories.Interface;
using System.Collections.ObjectModel;

namespace Payment.API.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IPaymentContext _context;
        private readonly ILogger<PaymentController> _logger;

        public PaymentRepository(IPaymentContext context,
            ILogger<PaymentController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> AddPayment(DTO.Payment payment)
        {
            var selectedAccount = await _context.AccountBalances.Find(p => p.Email == payment.ToEmail).FirstOrDefaultAsync();
            if(selectedAccount != null)
            {
                selectedAccount.Balance = selectedAccount.Balance + payment.Amount;

                var updateResult = await _context
                                            .AccountBalances
                                            .ReplaceOneAsync(filter: g => g.Id == selectedAccount.Id, replacement: selectedAccount);

                return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
            }
            return false;
        }

        public async Task<AccountBalance> GetBalance(string email)
        {
            return await _context
                           .AccountBalances
                           .Find(p => p.Email == email)
                           .FirstOrDefaultAsync();
        }
    }
}
