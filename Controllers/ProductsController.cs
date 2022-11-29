using GameDrewTotal.Data;
using GameDrewTotal.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GameDrewTotal.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : Controller
    {
        private readonly IGameRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IGameRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_repository.GetAllProducts());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("failed to get products");
            }
        }
    }
}
