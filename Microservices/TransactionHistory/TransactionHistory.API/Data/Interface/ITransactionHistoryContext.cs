using MongoDB.Driver;

namespace TransactionHistory.API.Data.Interface
{
    public interface ITransactionHistoryContext
    {
        IMongoCollection<Entities.TransactionHistory> TransactionHistories { get; }
    }
}
