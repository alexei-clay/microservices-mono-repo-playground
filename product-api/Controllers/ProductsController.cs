using Microsoft.AspNetCore.Mvc;

namespace product_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] ProductsList = new[]
        {
            "Title", "Homeowners", "Auto", "Life", "Earthquake", "Flood"
        };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            var productsList = Enumerable.Range(1, 5).Select(index => new Product
            {
                Id = Random.Shared.Next(0, 3232323),
                ProductType = ProductsList[Random.Shared.Next(ProductsList.Length)]
            }).ToArray();

            return productsList;
        }
    }
}