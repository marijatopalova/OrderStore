using Microsoft.AspNetCore.Mvc;
using OrderStore.Domain.Interfaces;

namespace OrderStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet(nameof(GetOrders))]
        public async Task<IActionResult> GetOrders() => Ok(await unitOfWork.Orders.GetAll());

        [HttpGet(nameof(GetOrderByName))]
        public async Task<IActionResult> GetOrderByName([FromQuery] string Genre) => Ok(await unitOfWork.Orders.GetOrdersByOrderName(Genre));
    }
}
