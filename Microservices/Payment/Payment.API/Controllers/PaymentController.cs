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

        public PaymentController(IPaymentRepository repository,
            ILogger<PaymentController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("[action]", Name = "AddPayment")]
        [ProducesResponseType(typeof(DTO.Payment), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddPayment([FromBody] DTO.Payment payment)
        {
            var result = await _repository.AddPayment(payment);
            if(result)
                return Ok();
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
