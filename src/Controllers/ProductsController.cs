using System.Collections.Generic;
using Crafts.WebSite.Models;
using Crafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService) =>
            ProductService = productService;

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public IEnumerable<Product> Get() => ProductService.GetProducts();

        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            if (request?.ProductId == null)
                return BadRequest();

            ProductService.AddRating(request.ProductId, request.Rating);

            return Ok();
        }

        public class RatingRequest
        {
            public string? ProductId { get; set; }
            public int Rating { get; set; }
        }
    }
}
