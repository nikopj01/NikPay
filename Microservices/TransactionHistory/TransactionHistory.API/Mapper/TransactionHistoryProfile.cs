using AutoMapper;
using EventBus.Events;
using TransactionHistory.API.Commands.AddTransactionHistory;

namespace TransactionHistory.API.Mapper
{
    public class TransactionHistoryProfile : Profile
    {
        public TransactionHistoryProfile()
        {
            //CreateMap<AddTransactionHistoryCommand, AddPaymentEvent>().ReverseMap();
            CreateMap<AddPaymentEvent, AddTransactionHistoryCommand>()
                .ForMember(dest => dest.Datetime, act => act.MapFrom(src => src.Datetime))
                .ForMember(dest => dest.Amount, act => act.MapFrom(src => src.Amount))
                .ForMember(dest => dest.FromEmail, act => act.MapFrom(src => src.FromEmail));
        }
    }
}
