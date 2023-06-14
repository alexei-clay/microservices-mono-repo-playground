using Microsoft.AspNetCore.Mvc;

namespace payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentsController : ControllerBase
    {
        private static readonly string[] Statuses = new[]
        {
            "Pending", "Completed", "Initiated", "Submitted", "Canceled", "Rejected"
        };

        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(ILogger<PaymentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPayments")]
        public IEnumerable<Payment> Get()
        {
            var paymentStatuses = Enumerable.Range(1, 5).Select(index => new Payment
            {
                Id = Random.Shared.Next(0, 23928988),
                Status = Statuses[Random.Shared.Next(Statuses.Length)]
            }).ToArray();

            return paymentStatuses;
        }
    }
}