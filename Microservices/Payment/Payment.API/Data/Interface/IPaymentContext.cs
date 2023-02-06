using MongoDB.Driver;
using Payment.API.Entities;

namespace Payment.API.Data.Interface
{
    public interface IPaymentContext
    {
        IMongoCollection<AccountBalance> AccountBalances { get; }
    }
}
