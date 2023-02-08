using MediatR;

namespace TransactionHistory.API.Commands.AddTransactionHistory
{
    public class AddTransactionHistoryCommand : IRequest<int>
    {
        public DateTime Datetime { get; set; }
        public decimal Amount { get; set; }
        public string FromEmail { get; set; }
        public string FromFirstName { get; set; }
        public string FromLastName { get; set; }
        public string FromVendor { get; set; }
        public string ToEmail { get; set; }
    }
}
