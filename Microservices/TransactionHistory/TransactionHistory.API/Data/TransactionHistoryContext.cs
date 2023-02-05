using MongoDB.Driver;
using TransactionHistory.API.Data.Interface;

namespace TransactionHistory.API.Data
{
    public class TransactionHistoryContext : ITransactionHistoryContext
    {
        public TransactionHistoryContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

            TransactionHistories = database.GetCollection<Entities.TransactionHistory>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
            //CatalogContextSeed.SeedData(Histories);
        }
        public IMongoCollection<Entities.TransactionHistory> TransactionHistories { get; }
    }
}
