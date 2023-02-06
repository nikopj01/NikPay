using Payment.API.Entities;

namespace Payment.API.Repositories.Interface
{
    public interface IPaymentRepository
    {
        Task<bool> AddPayment(DTO.Payment Payment);
        Task<AccountBalance> GetBalance(string email);
    }
}
