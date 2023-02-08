using MongoDB.Driver;
using Payment.API.Data.Interface;
using Payment.API.Entities;

namespace Payment.API.Data
{
    public class PaymentContext : IPaymentContext
    {
        public PaymentContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            AccountBalances = database.GetCollection<AccountBalance>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            PaymentContextSeed.SeedData(AccountBalances);
        }
        public IMongoCollection<AccountBalance> AccountBalances { get; }
    }
}
