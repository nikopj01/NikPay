using TransactionHistory.API.Data.Interface;
using TransactionHistory.API.Data;
using TransactionHistory.API.Repositories.Interface;
using TransactionHistory.API.Repositories;

namespace TransactionHistory.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITransactionHistoryContext, TransactionHistoryContext>();
            services.AddScoped<ITransactionHistoryRepository, TransactionHistoryRepository>();
            return services;
        }
    }
}
