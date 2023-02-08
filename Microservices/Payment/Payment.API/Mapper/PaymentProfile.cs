using AutoMapper;
using EventBus.Events;

namespace Payment.API.Mapper
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<DTO.Payment, AddPaymentEvent>().ReverseMap();
        }
    }
}
