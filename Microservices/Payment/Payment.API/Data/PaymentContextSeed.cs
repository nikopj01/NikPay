using MongoDB.Driver;
using Payment.API.Entities;

namespace Payment.API.Data
{
    public class PaymentContextSeed
    {
        public static void SeedData(IMongoCollection<AccountBalance> accountBalanceCollection)
        {
            bool existaccountBalance = accountBalanceCollection.Find(p => true).Any();
            if (!existaccountBalance)
            {
                accountBalanceCollection.InsertManyAsync(GetPreconfiguredAccountBalances());
            }
        }

        private static IEnumerable<AccountBalance> GetPreconfiguredAccountBalances()
        {
            return new List<AccountBalance>()
            {
                new AccountBalance()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Email = "nikopj@gmail.com",
                    Balance = 22
                },
                new AccountBalance()
                {
                    Id = "123d2149e77312a3990b47f5",
                    Email = "tina@gmail.com",
                    Balance = 11
                }
            };
        }
    }
}
