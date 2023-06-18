using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TransactionHistory.API.Repositories.Interface;

namespace TransactionHistory.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TransactionHistoryController : Controller
    {
        private readonly ITransactionHistoryRepository _repository;
        private readonly ILogger<TransactionHistoryController> _logger;

        public TransactionHistoryController(ITransactionHistoryRepository repository,
            ILogger<TransactionHistoryController> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("[action]/{email}", Name = "GetTransactionHistoryByEmail")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Entities.TransactionHistory), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Entities.TransactionHistory>> GetTransactionHistoryByEmail(string email)
        {
            var history = await _repository.GetTransactionHistory(email);

            if (history == null)
            {
                _logger.LogError($"Transaction Historyy with email: {email}, not found.");
                return NotFound();
            }

            return Ok(history);
        }

        //[HttpPost("[action]", Name = "AddTransactionHistory")]
        //[ProducesResponseType(typeof(Entities.TransactionHistory), (int)HttpStatusCode.OK)]
        //public async Task<IActionResult> AddTransactionHistory([FromBody] Entities.TransactionHistory history)
        //{
        //    await _repository.AddTransactionHistory(history);
        //    return Ok();
        //}
    }
}
