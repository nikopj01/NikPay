using Payment.API.Data;
using Payment.API.Data.Interface;
using Payment.API.Repositories;
using Payment.API.Repositories.Interface;

namespace Payment.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPaymentContext, PaymentContext>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            return services;
        }
    }
}
