using Microsoft.AspNetCore.Mvc;

namespace customer_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Elon Musk", "James Driskel", "Wily Jones", "Kelly Slater", "Joe Kinder"
        };

        private readonly ILogger<CustomersController> _logger;

        public CustomersController(ILogger<CustomersController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCustomers")]
        public IEnumerable<Customer> Get()
        {
            var customers = Enumerable.Range(1, 5).Select(index => new Customer
            {
                Id = Random.Shared.Next(0,28398298),
                Name = Names[Random.Shared.Next(Names.Length)]
            }).ToArray();

            return customers;
        }
    }
}