using AutoMapper;
using EventBus.Events;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Repositories.Interface;
using System.Net;

namespace Payment.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository _repository;
        private readonly ILogger<PaymentController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public PaymentController(IPaymentRepository repository,
            ILogger<PaymentController> logger, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _publishEndpoint = publishEndpoint ?? throw new ArgumentNullException(nameof(publishEndpoint));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("[action]", Name = "AddPayment")]
        [ProducesResponseType(typeof(DTO.Payment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddPayment([FromBody] DTO.Payment payment)
        {
            var result = await _repository.AddPayment(payment);
            if (result)
            {
                var eventMessage = _mapper.Map<AddPaymentEvent>(payment);
                //await _publishEndpoint.Publish<AddPaymentEvent>(eventMessage);
                await _publishEndpoint.Publish(eventMessage);
                return Ok();
            }
            else
            {
                _logger.LogError($"Fail To make Payment. From : {payment.FromEmail} ; To : {payment.ToEmail}");
                return NotFound();
            }
        }

        [HttpGet("[action]/{email}", Name = "GetBalanceByEmail")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(decimal), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<decimal>> GetBalanceByEmail(string email)
        {
            var product = await _repository.GetBalance(email);

            if (product == null)
            {
                _logger.LogError($"Balance with email: {email}, not found.");
                return NotFound();
            }

            return Ok(product.Balance);
        }
    }
}
