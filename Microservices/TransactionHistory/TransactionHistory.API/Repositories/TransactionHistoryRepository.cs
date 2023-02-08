using MongoDB.Driver;
using TransactionHistory.API.Data.Interface;
using TransactionHistory.API.Repositories.Interface;

namespace TransactionHistory.API.Repositories
{
    public class TransactionHistoryRepository : ITransactionHistoryRepository
    {
        private readonly ITransactionHistoryContext _context;

        public TransactionHistoryRepository(ITransactionHistoryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.TransactionHistory>> GetTransactionHistory(string email)
        {
            FilterDefinition<Entities.TransactionHistory> filter = Builders<Entities.TransactionHistory>.Filter.
                Eq(p => p.ToEmail, email);

            return await _context
                            .TransactionHistories
                            .Find(filter)
                            .ToListAsync();
        }

        public async Task AddTransactionHistory(Entities.TransactionHistory history)
        {
            await _context.TransactionHistories.InsertOneAsync(history);
        }
    }
}
