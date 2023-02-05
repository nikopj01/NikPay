namespace TransactionHistory.API.Repositories.Interface
{
    public interface ITransactionHistoryRepository
    {
        Task<IEnumerable<Entities.TransactionHistory>> GetTransactionHistory(string email);
        Task AddTransactionHistory(Entities.TransactionHistory transactionHistory);
    }
}
