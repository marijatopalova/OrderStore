using Microsoft.AspNetCore.Mvc;
using OrderStore.Domain.Interfaces;
using OrderStore.Domain.Models;

namespace OrderStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet(nameof(CreateProduct))]
        public IActionResult CreateProduct(Product product)
        {
            var result = unitOfWork.Products.Add(product);
            unitOfWork.Complete();

            if (result is not null) return Ok("Product created!");
            else return BadRequest("Error in creating the product.");
        }

        [HttpPut(nameof(UpdateProduct))]
        public IActionResult UpdateProduct(Product product)
        {
            unitOfWork.Products.Update(product);
            unitOfWork.Complete();
            return Ok("Product updated.");
        }
    }
}
