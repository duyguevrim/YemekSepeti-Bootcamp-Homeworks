
using GenericRepo.Domain.Response.Product;
using GenericRepo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GenericRepo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger,
                                   IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProductResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _productService.GetProduct(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
    }
}