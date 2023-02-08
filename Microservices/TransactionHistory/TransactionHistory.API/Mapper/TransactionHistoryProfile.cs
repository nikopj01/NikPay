using AutoMapper;
using EventBus.Events;
using TransactionHistory.API.Commands.AddTransactionHistory;

namespace TransactionHistory.API.Mapper
{
    public class TransactionHistoryProfile : Profile
    {
        public TransactionHistoryProfile()
        {
            CreateMap<AddTransactionHistoryCommand, AddPaymentEvent>().ReverseMap();
        }
    }
}
