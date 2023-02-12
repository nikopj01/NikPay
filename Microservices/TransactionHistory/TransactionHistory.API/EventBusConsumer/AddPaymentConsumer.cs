using AutoMapper;
using EventBus.Events;
using MassTransit;
using MediatR;
using TransactionHistory.API.Commands.AddTransactionHistory;

namespace TransactionHistory.API.EventBusConsumer
{
    public class AddPaymentConsumer : IConsumer<AddPaymentEvent>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<AddPaymentConsumer> _logger;

        public AddPaymentConsumer(IMediator mediator, IMapper mapper, ILogger<AddPaymentConsumer> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Consume(ConsumeContext<AddPaymentEvent> context)
        {
            var command = _mapper.Map<AddTransactionHistoryCommand>(context.Message);
            var result = await _mediator.Send(command);
            _logger.LogInformation("AddPaymentEvent consumed successfully. Created Order Id : {newPaymentId}", result);
        }
    }
}
