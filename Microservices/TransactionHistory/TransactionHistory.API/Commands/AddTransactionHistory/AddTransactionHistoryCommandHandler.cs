using AutoMapper;
using MassTransit.Transports;
using MediatR;

namespace TransactionHistory.API.Commands.AddTransactionHistory
{
    public class AddTransactionHistoryCommandHandler : IRequestHandler<AddTransactionHistoryCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILogger<AddTransactionHistoryCommandHandler> _logger;

        public AddTransactionHistoryCommandHandler(IMapper mapper, ILogger<AddTransactionHistoryCommandHandler> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<int> Handle(AddTransactionHistoryCommand request, CancellationToken cancellationToken)
        {
            //var orderEntity = _mapper.Map<Order>(request);
            //var newOrder = await _orderRepository.AddAsync(orderEntity);

            //_logger.LogInformation($"Order {newOrder.Id} is successfully created.");
            var result = request;
            //await SendMail(newOrder);

            //return newOrder.Id;
            return 1;
        }

        //private async Task SendMail(Order order)
        //{
        //    var email = new Email() { To = "ezozkme@gmail.com", Body = $"Order was created.", Subject = "Order was created" };

        //    try
        //    {
        //        await _emailService.SendEmail(email);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Order {order.Id} failed due to an error with the mail service: {ex.Message}");
        //    }
        //}
    }
}
